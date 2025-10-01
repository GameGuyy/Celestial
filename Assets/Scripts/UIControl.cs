using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIControl: MonoBehaviour 
{
	GameObject cam;

	void Start () 
	{
		cam = GameObject.Find ("Main Camera");
		if (PlayerPrefs.HasKey ("Mars")) 
		{
			cam.GetComponent<CameraMovement> ().enabled = false;
			cam.GetComponent<PlanetariumCamera>().enabled = true;
		}
		else 
			StartCoroutine (PanOff ());
	}
	
	IEnumerator PanOff()
	{
		yield return new WaitForSeconds (7);
		cam.GetComponent<CameraMovement> ().enabled = false;
		cam.GetComponent<PlanetariumCamera>().enabled = true;
	}




}
