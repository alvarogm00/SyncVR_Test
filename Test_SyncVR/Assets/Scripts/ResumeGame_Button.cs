using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame_Button : Button
{
    public override void PressButton()
    {
        gm.ResumeGame();
    }
}
