using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondTrigger : MonoBehaviour
{

    public static bool triggeredSecond = false;
    private void OnTriggerEnter(Collider other)
    {
        triggeredSecond = true;
        Debug.Log("SECOND TRIGGERED");
    }
}
