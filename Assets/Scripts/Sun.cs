using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float turnSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(turnSpeed * Time.deltaTime, 0, 0),Space.Self);
    }
}
