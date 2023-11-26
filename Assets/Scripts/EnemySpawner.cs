using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs;

    [SerializeField]
    private float spawnTime;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(enemyPrefabs[0], transform);
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
                GameObject.Instantiate(enemyPrefabs[0], transform);
                timer = 0; //reset our timer
            }
            else
            {
                GameObject.Instantiate(enemyPrefabs[1], transform);
                timer = 0; //reset our timer
            }
        }
    }
}
