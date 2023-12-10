using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs;

    [SerializeField]
    private float spawnTime; //time per spawn

    private float timer; //internal timer

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(enemyPrefabs[0], transform); //spawn common enemy first frame
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnTime)
        {
            timer += Time.deltaTime; //keep adding time between frames until it reaches time to spawn another pillar
        }
        else
        {
            int randInt = Random.Range(0, 100);

            //Breaking down enemy spawn percentages
            if(randInt < 70)    //75% chance to spawn common enemies
            {
                GameObject.Instantiate(enemyPrefabs[0], transform);
            }
            else if(randInt >= 70 && randInt < 85)  //15% chance to spawn phantom enemies
            {
                GameObject.Instantiate(enemyPrefabs[1], transform);
            }
            else if (randInt >= 85 && randInt < 95) //10% chance to spawn ranged enemies
            {
                GameObject.Instantiate(enemyPrefabs[2], transform);
            }
            else  //5% chance to spawn elite enemies
            {
                GameObject.Instantiate(enemyPrefabs[3], transform);
            }
        }
    }
}
