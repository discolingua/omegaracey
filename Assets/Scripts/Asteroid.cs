using UnityEngine;

public class Asteroid : MonoBehaviour {

    private Transform myTrans;
    private GameObject uiTrans;
    private Transform asteroidTransform;
    public Transform asteroidPrefab;
    public bool splitThis = true;
    public int splitCopies = 2;
    public int score = 100;

    void Awake() {
        myTrans = transform;
    }

    void Start() {

        // ui object for updating score
        uiTrans = GameObject.Find("Canvas");
        
        // set random rotation
        Quaternion rot = Quaternion.LookRotation(myTrans.forward, myTrans.up);
        rot *= Quaternion.Euler(0,0, Random.Range(-180.0f, 180.0f));
        myTrans.rotation = rot;
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider) {

        int myScore;
        
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null) {

            // destroy the shot
            Destroy(shot.gameObject);

            if (splitThis) {
                for (int i = 1; i <= splitCopies; i++) {
                    asteroidTransform = Instantiate(asteroidPrefab, myTrans.position, Quaternion.identity) as Transform;
                }
            }

            // increment score
            uiTrans.GetComponent<UIScript>().scoreInt += score;
            uiTrans.GetComponent<UIScript>().scoreText.text = uiTrans.GetComponent<UIScript>().scoreInt.ToString("D8");

            
            // destroy this asteroid
            Destroy(gameObject);
        }
    }

}