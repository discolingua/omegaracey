using UnityEngine;

public class SkullShip : MonoBehaviour {

    public Transform target;
    private Transform myTrans;
    private WeaponScript[] weapons;

    public float speed = 1.0f;

    void Awake() {

        // cache transform for performance
        myTrans = transform;

        weapons = GetComponentsInChildren<WeaponScript>();
    }

    void Update() {
        foreach (WeaponScript weapon in weapons) {
            if (weapon != null && weapon.CanAttack) {
                weapon.Attack(true);
            }
        }
    }

    void FixedUpdate() {

        // calculate rotation towards player
        Vector3 dir = target.transform.position - myTrans.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        myTrans.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

        // move forward
        myTrans.Translate(speed * Time.deltaTime,0,0);
      
    }
}