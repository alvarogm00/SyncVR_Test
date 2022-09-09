using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame_Button : Button
{
    public override void PressButton()
    {
        gm.StartGame();
    }
}
