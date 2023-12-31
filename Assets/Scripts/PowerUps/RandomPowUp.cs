using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowUp : MonoBehaviour
{

    [SerializeField]
    List<PowerUpBase> powerUpPrefabs = new List<PowerUpBase>();

    // Start is called before the first frame update
    void Start()
    {
        //Spawns a random power up from a list of powUps
        int randomInd = Random.Range(0, powerUpPrefabs.Count);
        Instantiate(powerUpPrefabs[randomInd], transform);
    }
}
