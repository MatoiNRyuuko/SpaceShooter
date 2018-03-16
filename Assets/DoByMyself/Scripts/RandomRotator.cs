using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float RotaSpeed;
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * RotaSpeed;
	}

}
