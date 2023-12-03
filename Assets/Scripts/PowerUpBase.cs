using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{

    [SerializeField]
    private PickUp PowUpPrefab;
    

    public void Start()
    {
        PickUp instance = Instantiate(PowUpPrefab, transform);
        instance.Initializing(this);
    }

    public abstract void Apply(PlayerController player);
}
