using UnityEngine;

/// <summary>
///   Launch projectile
/// </summary>

public class WeaponScript : MonoBehaviour {

    public Transform shotPrefab;
    public float shootingRate = 0.2f;

    private float shotCooldown;
    private Transform myTrans;

    void Awake() {
        myTrans = transform;
    }

    void Start() {
        shotCooldown = 0f;
    }

    void Update() {
        if (shotCooldown > 0) {
            shotCooldown -= Time.deltaTime;
        }
    }

    // shooting from another script

    public void Attack(bool isEnemy) {
        if (CanAttack) {
            shotCooldown = shootingRate;

            // create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // rotate to face player, multiply quaternion to fix facing
            Quaternion rot = Quaternion.LookRotation(myTrans.forward, myTrans.up);
            // rot *= Quaternion.Euler(0, 0, -90);
            
            shotTransform.position = myTrans.position;
            shotTransform.rotation = rot;

            // the isEnemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null) {
                shot.isEnemyShot = isEnemy;
            }

            // MoveScript to keep it in motion
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
        }
    }

    // ready to create a new projectile?

    public bool CanAttack {
        get {
            return shotCooldown <= 0f;
        }
    }
}