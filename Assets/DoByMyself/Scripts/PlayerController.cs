using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public float speed;
    public float tilt;
    public Boundary boundary;
    // Use this for initialization

    private float nextShot = 0;
    public float fireRate;
    public GameObject shot;
    public Transform BulletSqawnPosition;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")&&Time.time > nextShot){
            nextShot = Time.time + fireRate;
            Instantiate(shot, BulletSqawnPosition.position, BulletSqawnPosition.rotation);

            GetComponent<AudioSource>().Play();
        }
	}
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 ShipMoveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = ShipMoveVector * speed;

        GetComponent<Rigidbody>().rotation = Quaternion.Euler( 0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

        //GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.x * -tilt,0.0f, 0.0f);

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
    }
}
