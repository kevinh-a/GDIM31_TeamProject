using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Delete : MonoBehaviour
{
    private void Awake()
    {

        StartCoroutine(waiter());
        
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        Object.Destroy(this.gameObject);
    }

}
