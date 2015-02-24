using UnityEngine;

/// <summary>
///   Launch projectile
/// </summary>

public class WeaponScript : MonoBehaviour {

    public Transform shotPrefab;
    public float shootingRate = 0.2f;

    private float shotCooldown;

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

            // assign position
            shotTransform.position = transform.position;

            // the isEnemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null) {
                shot.isEnemyShot = isEnemy;
            }

            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null) {
                move.direction = this.transform.up;
            }
        }
    }

    // ready to create a new projectile?

    public bool CanAttack {
        get {
            return shotCooldown <= 0f;
        }
    }
}