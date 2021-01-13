using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class kameraSeuraa : MonoBehaviour
{
    public Transform target;
    public float PosLerp = 0.2f;
    public float RotLerp = 0.25f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, PosLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, RotLerp);

    }

}
