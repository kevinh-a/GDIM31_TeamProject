using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Transform shootingPoint;
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    PlayerController playerCon;

    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame || (Keyboard.current.qKey.wasPressedThisFrame))
        {
            //Spawns the bullet
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            //Credit: https://discussions.unity.com/t/how-can-i-instantiate-a-object-with-a-constructor/245374/3
            //This gives each bullet the amount of damage it does
            bullet.GetComponent<BulletVelocity>().Init(playerCon.GetBulletDmg());
        }
    }
}
