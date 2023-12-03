using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class FlipPlayer : MonoBehaviour
{
   
    void Update()
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 180, 0);
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 180, 0);
        }

    }
}
