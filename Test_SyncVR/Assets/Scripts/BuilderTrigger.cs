using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderTrigger : MonoBehaviour
{
    public int id;

    RobotBuilder robotBuilder;
    void Start()
    {
        robotBuilder = FindObjectOfType<RobotBuilder>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Shape>())
        {
            if(other.GetComponent<Shape>().id == id)
                robotBuilder.BuildPart(id);

            other.GetComponent<Shape>().Detach();
        }
    }
}
