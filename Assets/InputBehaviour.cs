using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

    private bool startedDoubleTap;
    private float timeSinceFirstTap;

    private Transform card;
    private float dist;
    private Vector3 dragOffset;
    private Plane plane;

    public float TapInterval = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (startedDoubleTap)
        {
            timeSinceFirstTap += Time.deltaTime;
            if (timeSinceFirstTap > TapInterval)
            {
                startedDoubleTap = false;
                timeSinceFirstTap = 0;
            }
        }

        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Card")
                {
                    card = hit.transform;
                    plane.SetNormalAndPosition(Camera.main.transform.forward, card.position);
                    Ray cardRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float dist;
                    plane.Raycast(ray, out dist);
                    dragOffset = card.position - ray.GetPoint(dist);
                    Debug.Log("Got card!");
                }
            }
        }

        if (touch.phase == TouchPhase.Moved)
        {
            if (card != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float dist;
                plane.Raycast(ray, out dist);
                Vector3 v3Pos = ray.GetPoint(dist);
                card.position = v3Pos + dragOffset;
            }
        }

        if (touch.phase == TouchPhase.Ended)
        {
            startedDoubleTap = true;
            card = null;
        }
    }

    public Vector3 GetTarget()
    {
        if (Input.touchCount == 0) return Vector3.zero;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                return hit.point;
            }
        }
        return Vector3.zero;
    }

    public bool Tap()
    {
        if (Input.touchCount == 0) return false;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Ended)
        {
            return true;
        }
        return false;
    }

    public bool DoubleTap()
    {
        if (Input.touchCount == 0) return false;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Ended)
        {
            if (startedDoubleTap)
            {
                if (timeSinceFirstTap < TapInterval)
                {
                    startedDoubleTap = false;
                    timeSinceFirstTap = 0;
                    return true;
                }
            }
            else
            {
                startedDoubleTap = true;
                return false;
            }
        }

        return false;
    }

    public bool Drag()
    {
        if (Input.touchCount == 0) return false;
        else return true;
    }

    public Vector3 GetMovementDirection()
    {
        if (Input.touchCount == 0) return Vector2.zero;
        Touch touch = Input.GetTouch(0);

        Vector2 screenPosition = touch.position;
        Vector2 middleOfScreen = new Vector2(Screen.width / 2f, Screen.height / 2f);

        Vector2 positionDelta = screenPosition - middleOfScreen;

        return positionDelta.normalized;
    }
}
