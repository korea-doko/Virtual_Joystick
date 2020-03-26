using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TK_Virtual_Joystick;

public class TestMove : MonoBehaviour
{
    public VirtualJoystick virtualJoystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( virtualJoystick.InputDir != Vector2.zero)
        {
            this.transform.Translate(virtualJoystick.InputDir*0.05f);
        }
    }
}
