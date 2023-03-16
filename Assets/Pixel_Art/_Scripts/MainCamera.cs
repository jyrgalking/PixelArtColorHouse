using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private Vector3 dragDelta;
    private Vector3 beginTouchPosition;
    private Vector3 beginCamPosition;

    public Camera fixedCamera;
    public Camera mainCamera;
    public Board board;
    public LeanScreenDepth ScreenDepth;

    public GameObject lessonBlock;

    public bool dragging, isDragLocked;

    public static MainCamera Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnBeginDrag()
    {
        if (isDragLocked) return;

        bool touchCheck = Input.touchCount == 1 && Application.isMobilePlatform || !Application.isMobilePlatform;
        if (touchCheck)
        {
            dragging = true;
        }
    }

    public void OnDrag()
    {
        if (isDragLocked || !dragging) return;

        // Get the fingers we want to use
        var fingers = LeanTouch.GetFingers(false, false, 0);

        // Get the last and current screen point of all fingers
        var lastScreenPoint = LeanGesture.GetLastScreenCenter(fingers);
        var screenPoint = LeanGesture.GetScreenCenter(fingers);

        // Get the world delta of them after conversion
        var worldDelta = ScreenDepth.ConvertDelta(lastScreenPoint, screenPoint, gameObject);

        // Pan the camera based on the world delta
        transform.position -= worldDelta * 1;
    }


    public void ResetZoom()
    {
        mainCamera.orthographicSize = board.maxOrthographicSize;
        Debug.Log("Max size => " + board.maxOrthographicSize);
    }

    public void WinZoom()
    {
        mainCamera.orthographicSize = board.maxOrthographicSize * 2;
    }

    public void OnEndDrag()
    {
        dragging = false;
    }

    public float orthoZoomSpeed = 0.35f;
    void Update()
    {

        if(board.maxOrthographicSize > mainCamera.orthographicSize)
        {
            //Hide Zoom Lesson
            int lesson = PlayerPrefs.GetInt("lesson", 0);
            if (lesson == 0)
            {
                Debug.Log("hide zoom lesson");
                lessonBlock.SetActive(false);
                PlayerPrefs.SetInt("lesson", 1);
            }
        }


        //mainCamera.orthographicSize = ZoomVar.zoom;

        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            dragging = false;
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            //Hide Zoom Lesson
            int lesson = PlayerPrefs.GetInt("lesson", 0);
            if (lesson == 0)
            {
                Debug.Log("hide zoom lesson");
                lessonBlock.SetActive(false);
                PlayerPrefs.SetInt("lesson", 1);
            }

            // ... change the orthographic size based on the change in distance between the touches.
            mainCamera.orthographicSize += deltaMagnitudeDiff * (mainCamera.orthographicSize / 8f) * Time.deltaTime;


            // Make sure the orthographic size never drops below zero.
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, board.minOrthographicSize, board.maxOrthographicSize);

            //mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, ZoomVar.zoomMin, ZoomVar.zoomMax);


        }
    }
}
