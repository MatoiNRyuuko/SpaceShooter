using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {
    public GameObject explosion;
    public GameObject ShipExplosion;
    private GameController gamecontroller;
    private void Start()
    {
        if (gamecontroller == null)
        {
            GameObject gamecontrollerObj = GameObject.FindWithTag("GameController");
            gamecontroller = gamecontrollerObj.GetComponent<GameController>();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        if(other.tag == "Ship")
        {
            Instantiate(ShipExplosion, other.transform.position, other.transform.rotation);
            gamecontroller.gameover = true;
            Debug.Log(gamecontroller.gameover);
            Destroy(other.gameObject);
        }
        Instantiate(explosion,other.transform.position, other.transform.rotation);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }


}
