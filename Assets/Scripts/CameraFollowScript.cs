using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    private Transform player;
    private Transform myTrans;

    void Awake() {
        myTrans = transform;
    }

    void Start() {
        player = GameObject.Find ("PlayerShip").transform;
    }


    void Update() {

        Vector3 playerPos = player.position;
        playerPos.z = myTrans.position.z;
        myTrans.position = playerPos;

    }
}