using UnityEngine;


/// <summary>
///   Player controller and behavior
/// </summary>

public class PlayerScript : MonoBehaviour {

    public float directionInput;
    public float thrustInput;
    public float shipRotationSpeed = 2.0f;
    public float speed = 25.0f;

    private RaycastHit2D hit;

    void Start () {
        // rigidbody2D.drag = 1.0f;
    }

	void Update () {
        // Retrieve axis information
        directionInput = Input.GetAxis("Horizontal");
        thrustInput = Input.GetAxis("Vertical");


        // Reflection

        hit = Physics2D.Raycast(transform.position, transform.up, 0.5f, 1 << LayerMask.NameToLayer("walls"));
        Debug.DrawRay(transform.position, transform.up, Color.red);


        // Shooting

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot) {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null) {
                weapon.Attack(false); // not isEnemy
            }
        }

	}

    void FixedUpdate() {
        // Move the game object
        transform.Rotate(0.0f, 0.0f, directionInput * shipRotationSpeed * -1);
        rigidbody2D.velocity = (Vector2)transform.TransformDirection(Vector3.up) * thrustInput * speed;
        //  rigidbody2D.AddForce ((Vector2)transform.TransformDirection(Vector3.up) * thrustInput * speed);

        if (hit) {
            Vector3 dir = Vector3.Reflect (transform.position.normalized, hit.normal);
            float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        
     }

    void OnCollisionEnter2D(Collision2D collision) {
        bool damagePlayer = false;
    }

    void OnDestroy() {
        // Game over.
        // Add the script to the parent because the current game object
        // is likely to be destroyed immediately
        // transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}