using UnityEngine;

public class MoveScript : MonoBehaviour {

    // object speed
    public Vector2 speed = new Vector2(10,10);

    // moving direction
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    void Update() {
        movement = new Vector2( speed.x * direction.x,
                                speed.y * direction.y);
    }

    void FixedUpdate() {
        rigidbody2D.velocity = movement;
    }
}