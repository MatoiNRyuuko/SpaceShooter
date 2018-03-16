using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float BulletSpeed ;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.forward * BulletSpeed;

}
}
