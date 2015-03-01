using UnityEngine;

public class SkullShip : MonoBehaviour {

    public Transform target;
    private Transform myTrans;

    private float maxAngularSpeedDegrees = 0.3f;

    void Awake() {
        myTrans = transform;
    }

    void Update() {
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - myTrans.position,
                                                      myTrans.TransformDirection(Vector3.up));
        myTrans.rotation = Quaternion.RotateTowards(myTrans.rotation, new Quaternion(0,0,rotation.z, rotation.w), 
                                                    maxAngularSpeedDegrees * Time.time);
        // myTrans.rotation = Quaternion.Slerp(myTrans.rotation, new Quaternion(0,0,rotation.z, rotation.w), Time.time * speed);
        // myTrans.rotation = new Quaternion(0,0, rotation.z, rotation.w);
        // myTrans.Rotate(0.0f, 0.0f, 1);
    }
}