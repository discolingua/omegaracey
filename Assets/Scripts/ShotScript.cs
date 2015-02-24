using UnityEngine;

public class ShotScript : MonoBehaviour {

    // damage inflicted
    public int damage = 1;

    // projectile damage player or enemies?
    public bool isEnemyShot = false;

    void Start() {
        // limited time to live
        Destroy(gameObject, 4); // 2 sec
    }
}