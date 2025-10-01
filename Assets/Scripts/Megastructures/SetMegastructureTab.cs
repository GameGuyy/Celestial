using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMegastructureTab : MonoBehaviour 
{
	void CheckStructureInfoPanel()
	{
		bool checker = GameObject.Find ("Main Camera").GetComponent<SurfaceUI> ().StructureInfoOn;
		if (checker == true) 
		{
			gameObject.GetComponent<Animator> ().enabled = false;
			gameObject.SetActive (false);
		}
	}

}
