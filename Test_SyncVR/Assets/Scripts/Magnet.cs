using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    Transform attachTransform;

    private void Start()
    {
        attachTransform = GetComponentInChildren<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Shape>())
        {
            Vector3 anchorPosition = transform.position;
            anchorPosition.y -= other.transform.localScale.y;
            other.transform.position = anchorPosition;
            other.transform.rotation = transform.rotation;
            other.transform.SetParent(transform);
        }
    }
}
