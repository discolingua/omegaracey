using UnityEngine;

public class MoveScript : MonoBehaviour {

    // object speed
    public float speed = 10.0f;
    private RaycastHit2D hit;
    private Transform myTrans;

    void Awake() {
        // cache transform for performance
        myTrans = transform;
        myTrans.rigidbody2D.angularVelocity = Mathf.Clamp(myTrans.rigidbody2D.angularVelocity, -5f, 5f);
    }

    void Update() {

        // raycast to check for wall reflection
        hit = Physics2D.Raycast(myTrans.position, myTrans.up, 0.2f, 1 << LayerMask.NameToLayer("walls"));

    }

    void FixedUpdate() {

        // keep shot moving forward
        myTrans.rigidbody2D.velocity = (Vector2)myTrans.TransformDirection(Vector3.up) * speed;


        // wall reflection
        if (hit) {
            Vector3 dir = Vector3.Reflect (rigidbody2D.velocity, hit.normal);
            myTrans.rigidbody2D.velocity = dir;
            float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            myTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}