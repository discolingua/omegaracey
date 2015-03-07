using UnityEngine;

public class Asteroid : MonoBehaviour {

    private Transform myTrans;
    private Transform asteroidTransform;
    public Transform asteroidPrefab;
    public bool splitThis = true;
    public int splitCopies = 2;

    void Awake() {
        myTrans = transform;
    }

    void Start() {
        // set random rotation
        Quaternion rot = Quaternion.LookRotation(myTrans.forward, myTrans.up);
        rot *= Quaternion.Euler(0,0, Random.Range(-180.0f, 180.0f));
        myTrans.rotation = rot;
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider) {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null) {

            // destroy the shot
            Destroy(shot.gameObject);

            if (splitThis) {
                for (int i = 1; i <= splitCopies; i++) {
                    asteroidTransform = Instantiate(asteroidPrefab, myTrans.position, Quaternion.identity) as Transform;
                }
            }
            
            // destroy this asteroid
            Destroy(gameObject);
        }
    }

}