using UnityEngine;

public class HealthScript : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true; // enemy or player?

    // inflict damage and check if the object should be destroyed

    public void Damage(int damageCount) {
        hp -= damageCount;

        if (hp <= 0) {
            // Dead!
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider) {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null) {
            if (shot.isEnemyShot != isEnemy) {
                Damage(shot.damage);

                // destroy the shot
                Destroy(shot.gameObject);
            }
        }
    }
}