using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame_Button : Button
{
    public override void PressButton()
    {

        gm.ExitGame();
    }
}
