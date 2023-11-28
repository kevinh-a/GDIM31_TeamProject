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
            if (Random.Range(0, 10) < 9)
            {
                GameObject.Instantiate(enemyPrefabs[0], transform); //spawn common enemy
                timer = 0; //reset our timer
            }
            else
            {
                GameObject.Instantiate(enemyPrefabs[1], transform); //rare spawn elite/boss
                timer = 0; //reset our timer
            }
        }
    }
}
