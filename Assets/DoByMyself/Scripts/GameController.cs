using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Thing;
    public Vector3 ThingVec;
    public int spawnThingNum;
    public bool gameover = false;

    private void Start()
    {
        StartCoroutine(SpawnThing());
    }
    private void Update()
    {
        if(gameover == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("_Main");
            }
        }
    }
    IEnumerator SpawnThing()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            for (int i = 0; i < spawnThingNum; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-ThingVec.x, ThingVec.x), ThingVec.y, ThingVec.z);

                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(Thing, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(2f);
        }


    }
}
