using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    protected GameManager gm;
    protected void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public virtual void PressButton() { }
}
