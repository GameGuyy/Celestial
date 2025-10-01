using UnityEngine;
using System.Collections;

public class RotateObstacle : MonoBehaviour {

	public float rotate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.Rotate (0,0,rotate *Time.deltaTime); //rotates 360 degrees per second around z axis
	}
	
	
}