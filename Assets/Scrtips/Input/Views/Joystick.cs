using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform indicator;

    public float radius;

    public void Init()
    {
        radius = this.GetComponent<SpriteRenderer>().size.x;

        Hide();
    }

    public void Show(Vector2 pos)
    {
        this.transform.position = pos;
        
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        indicator.position = this.transform.position;
        this.gameObject.SetActive(false);
    }

    public void MoveJoystickDir(Vector2 curPoint)
    {
        Vector2 dir = new Vector2
            (
                curPoint.x - this.transform.position.x,
                curPoint.y - this.transform.position.y
            );
        
        bool isLongerThanRadius = dir.magnitude >= radius ? true : false;
        
        if( isLongerThanRadius )
        {
            dir = dir.normalized;
            indicator.position = new Vector3
                (
                    this.transform.position.x + dir.x,
                    this.transform.position.y + dir.y,
                    this.transform.position.z
                 );    
        }
        else
        {
            indicator.position = new Vector3(curPoint.x, curPoint.y, indicator.position.z);
        }
    }

}
