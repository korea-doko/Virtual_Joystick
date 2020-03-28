using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// required Joystick is entire Joystick sub view.
/// outer Large circle is basically used.
/// </summary>
[RequireComponent(typeof(Joystick))]
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
