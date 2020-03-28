using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputView view;

    [SerializeField] private Vector2 clickPos;
    [SerializeField] private Vector2 inputDir;

    public GameObject test;
    
    // Start is called before the first frame update
    void Start()
    {
        clickPos = Vector2.zero;
        inputDir = Vector2.zero;

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

                    clickPos = Camera.main.ScreenToWorldPoint(touch.position);
                    view.ShowJoystick(clickPos);

                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:

                    Vector2 curPoint = Camera.main.ScreenToWorldPoint(touch.position);

                    inputDir = curPoint - clickPos;
                    inputDir.Normalize();

                    view.MoveJoystickDir(curPoint);
                    TestMove(inputDir);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    clickPos = Vector2.zero;
                    inputDir = Vector2.zero;

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
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            view.ShowJoystick(clickPos);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            view.MoveJoystickDir(curPos);


            inputDir = curPos - clickPos;
            inputDir.Normalize();           
            TestMove(inputDir);
        }

        if (Input.GetMouseButtonUp(0))
        {
            clickPos = Vector2.zero;
            inputDir = Vector2.zero;

            view.HideJoystick();
        }
    }

    public void TestMove(Vector2 dir)
    {
        test.transform.Translate(dir*0.05f);
    }
}
