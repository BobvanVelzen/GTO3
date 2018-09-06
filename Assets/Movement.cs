using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputBehaviour))]
public class Movement : MonoBehaviour {

    private InputBehaviour _input;

    public Vector3 target;
    public float smoothTime = 0.05f;

    public float movementSpeed = 5f;

	// Use this for initialization
	void Start () {
        _input = GetComponent<InputBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_input.Drag())
        {
            Vector3 movementDirection = _input.GetMovementDirection();
            Vector3 movement = new Vector3(movementDirection.x, 0, movementDirection.y);
            transform.Translate(movement * Time.deltaTime * movementSpeed);
        }

        if (_input.Tap())
        {
            //Vector3 iTarget = _input.GetTarget();
            //if (iTarget != Vector3.zero) target = iTarget;

            Debug.Log("Tap");
        }

        if (_input.DoubleTap())
        {
            Debug.Log("DoubleTap");
            Renderer r = GetComponentInChildren<Renderer>();
            r.material.SetColor("_Color", Random.ColorHSV());
        }

        //if (target != null)
        //{
        //    Vector3 targetPosition = new Vector3(target.x, transform.position.y, target.z);
        //    transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime);
        //}
    }
}
