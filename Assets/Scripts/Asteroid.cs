using UnityEngine;

public class Asteroid : MonoBehaviour {

    private Transform myTrans;
    public Transform asteroidPrefab;
    public bool splitThis = true;

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
                var asteroidTransform = Instantiate(asteroidPrefab, myTrans.position, Quaternion.identity) as Transform;
                var asteroidTransform2 = Instantiate(asteroidPrefab, myTrans.position, Quaternion.identity) as Transform;
            }
            
            // destroy this asteroid
            Destroy(gameObject);
        }
    }

}