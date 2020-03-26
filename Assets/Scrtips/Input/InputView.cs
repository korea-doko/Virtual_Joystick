using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : MonoBehaviour
{
    public Joystick joystick;


    
    public void Init()
    {
        joystick.Init();
    }

    public void ShowJoystick(Vector2 pos)
    {
        joystick.Show(pos);
    }

    public void HideJoystick()
    {
        joystick.Hide();
    }

    public void MoveJoystickDir(Vector2 curPoint)
    {
        joystick.MoveJoystickDir(curPoint);
    }
}
