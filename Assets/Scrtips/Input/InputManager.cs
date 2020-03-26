using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputView view;

    public Vector2 firstPoint;
    public Vector2 dir;

    public GameObject test;
    
    // Start is called before the first frame update
    void Start()
    {
        firstPoint = Vector2.zero;
        dir = Vector2.zero;

        view.Init();
    }

    // Update is called once per frame
    void Update()
    {

        MouseInput();

        TouchInput();
    }

    private void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    firstPoint = Camera.main.ScreenToWorldPoint(touch.position);
                    view.ShowJoystick(firstPoint);

                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:

                    Vector2 curPoint = Camera.main.ScreenToWorldPoint(touch.position);

                    dir = curPoint - firstPoint;
                    dir.Normalize();

                    view.MoveJoystickDir(curPoint);
                    TestMove(dir);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    firstPoint = Vector2.zero;
                    dir = Vector2.zero;

                    view.HideJoystick();

                    break;
                default:
                    break;
            }

        }
    }
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            view.ShowJoystick(firstPoint);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 curPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            dir = curPoint - firstPoint;
            dir.Normalize();

            view.MoveJoystickDir(curPoint);
            TestMove(dir);
        }

        if (Input.GetMouseButtonUp(0))
        {
            firstPoint = Vector2.zero;
            dir = Vector2.zero;

            view.HideJoystick();
        }
    }

    public void TestMove(Vector2 dir)
    {
        test.transform.Translate(dir*0.05f);
    }
}
