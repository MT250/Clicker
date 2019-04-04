using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Quaternion newRotation;

    [Range(.001f, .1f)]
    public float turnSpeed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        newRotation.z = UnityEngine.Random.Range(-360, 360);
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }

    private void Turn()
    {
        if (Mathf.Round(transform.rotation.z) == newRotation.z)
        {
            newRotation.z = UnityEngine.Random.Range(-360, 360);
        }
        else transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, turnSpeed * Time.deltaTime);
    }
}
