using UnityEngine;


/// <summary>
///   Player controller and behavior
/// </summary>

public class PlayerScript : MonoBehaviour {

    public float directionInput;
    public float thrustInput;
    public float shipRotationSpeed = 40.0f;
    public float speed = 25.0f;

    public Vector2 direction;

    private RaycastHit2D hit;
    private Transform myTrans; // cache transform for performance


    void Awake () {
        myTrans = transform;
    }

	void Update () {
        // Retrieve axis information
        directionInput = Input.GetAxis("Horizontal");
        thrustInput = Input.GetAxis("Vertical");

        if (thrustInput < 0) {
            thrustInput = 0;
        }

        // Reflection
        hit = Physics2D.Raycast(myTrans.position, myTrans.up, 0.5f, 1 << LayerMask.NameToLayer("walls"));


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
        myTrans.Rotate(0.0f, 0.0f, directionInput * shipRotationSpeed * -1);

        rigidbody2D.velocity = (Vector2)myTrans.TransformDirection(Vector3.up) * thrustInput * speed;


        if (hit) {

            // reflect our old velocity off the contact point's normal vector
            Vector3 dir = Vector3.Reflect (rigidbody2D.velocity, hit.normal);
            rigidbody2D.velocity = dir;

            // rotate to face the new velocity
            float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            myTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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