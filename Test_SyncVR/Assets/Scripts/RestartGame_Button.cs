using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame_Button : Button
{
    public override void PressButton()
    {
        gm.RestartGame();
    }
}
