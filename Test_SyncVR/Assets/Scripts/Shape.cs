using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public int id;

    Vector3 initialPos;
    Quaternion initialRotation;
    private void Start()
    {
        initialPos = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
       
    }
    public void Detach()
    {
        transform.parent = null; 
        transform.position = initialPos;
        transform.rotation = initialRotation;
    }
}
