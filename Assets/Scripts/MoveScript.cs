using UnityEngine;

public class MoveScript : MonoBehaviour {

    // object speed
    public float speed = 10.0f;

    // length of raycast to track different sized objects
    public float raycastLength = 0.2f;

    private RaycastHit2D hit;
    private Transform myTrans;

    void Awake() {
        // cache transform for performance
        myTrans = transform;
    }

    void Update() {

        // raycast to check for wall reflection
        hit = Physics2D.Raycast(myTrans.position, myTrans.up, raycastLength, 
                                1 << LayerMask.NameToLayer("walls"));

    }

    void FixedUpdate() {

        // keep shot moving forward
        myTrans.GetComponent<Rigidbody2D>().velocity = (Vector2)myTrans.TransformDirection(Vector3.up) * speed;


        // wall reflection
        if (hit) {
            Vector3 dir = Vector3.Reflect (GetComponent<Rigidbody2D>().velocity, hit.normal);
            myTrans.GetComponent<Rigidbody2D>().velocity = dir;
            float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            myTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}