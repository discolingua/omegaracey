using UnityEngine;
using System.Collections;

public class ParallaxScroll : MonoBehaviour {

    public float parallaxSpeed = 0.1f;

    private Transform cameraTrans;
    private Transform myTrans;

    void Awake() {
        myTrans = transform;
    }

    void Start () {
        cameraTrans = GameObject.Find ("Main Camera").transform;
    }

    void Update () {
        Vector3 cameraPos = cameraTrans.position;
        Vector3 tmpPos = myTrans.position;
        tmpPos.x = -cameraPos.x * parallaxSpeed;
        tmpPos.y = -cameraPos.y * parallaxSpeed;
        myTrans.position = tmpPos;
    }
}