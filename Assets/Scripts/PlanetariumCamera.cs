using UnityEngine;
using System.Collections;
using System;

public class PlanetariumCamera : MonoBehaviour {

	public enum CAMERA_MODES {
		INIT = 0,
		ORBIT = 1,
		MOVE = 2
	}

	public CAMERA_MODES cameraMode = CAMERA_MODES.ORBIT;

	public GameObject target;

	public float distance = 5.0f;
	public float xSpeed = 30.0f;
	public float ySpeed = 30.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	float x = 0.0f;
	float y = 0.0f;

	public float introFadeTime = 5f;

	void Start () 
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		if(PlayerPrefs.HasKey("Mars"))
		{
			distance = 4.34f;
			xSpeed = 10;
			ySpeed = 10;
			yMinLimit = -20;
			yMaxLimit = 80;
			gameObject.GetComponent<Camera> ().fieldOfView = 30;
			target = GameObject.Find ("Mars");
		}
	}
	void Update () 
	{
		
	}
	void LateUpdate () 
	{
		switch (cameraMode) 
		{
		case CAMERA_MODES.INIT:
			//InitCamera ();
			break;
		case CAMERA_MODES.ORBIT:
			OrbitCam ();
			break;
		}
	}

	void OrbitCam () {
		Vector2 inputDelta = Vector2.zero;

		#if UNITY_IOS && !UNITY_EDITOR
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			inputDelta = Input.GetTouch (0).deltaPosition;
		}
		#else
		if (Input.GetMouseButton (0)) {
			inputDelta.x = Input.GetAxis("Mouse X") * xSpeed * 10f * Time.deltaTime; // extra factor for mouse input
			inputDelta.y = Input.GetAxis("Mouse Y") * ySpeed * 10f * Time.deltaTime;
		} 
		#endif

		if (target) {
			x += inputDelta.x * xSpeed * distance * Time.deltaTime;
			y -= inputDelta.y * ySpeed * Time.deltaTime;

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);

			//Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 negDistance = -Vector3.forward * distance;
			Vector3 position = rotation * negDistance + target.transform.position;

			transform.rotation = rotation;
			transform.position = position;
		}
	}
		

	public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}