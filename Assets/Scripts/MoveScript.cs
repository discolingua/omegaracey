using UnityEngine;

public class MoveScript : MonoBehaviour {

    // object speed
    public float speed = 10.0f;
    private RaycastHit2D hit;

    void Update() {

        // raycast to check for wall reflection
        hit = Physics2D.Raycast(transform.position, transform.up, 0.5f, 1 << LayerMask.NameToLayer("walls"));
    }

    void FixedUpdate() {

        rigidbody2D.velocity = (Vector2)transform.TransformDirection(Vector3.up) * speed;

        // wall reflection
        if (hit) {
            Vector3 dir = Vector3.Reflect (transform.position.normalized, hit.normal);
            float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}