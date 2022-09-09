using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAnim : MonoBehaviour
{
    Animator anim;
    Button button;
    DroneController droneController;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void StartAnim(Button _button)
    {
        anim.SetBool("Activate", true);
        button = _button;
        droneController = null;
    }
    public void StartAnim(DroneController _droneController)
    {
        anim.SetBool("Activate", true);
        droneController = _droneController;
        button = null;
    }
    public void StopAnim()
    {
        anim.SetBool("Activate", false);
    }

    public void ActivateInteractable()
    {
        if (button != null)
            button.PressButton();
        else if (droneController != null)
        {
            print("Control Drone");
            droneController.enabled = true;
            droneController.ControlDrone();
        }

        StopAnim();
    }
}
