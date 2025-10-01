using UnityEngine;
using System.Collections;

public class RotateCarrier : MonoBehaviour {
	
	public float RotateSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (RotateSpeed*Time.deltaTime,0,0); //rotates 360 degrees per second around z axis
	}
	
	
}