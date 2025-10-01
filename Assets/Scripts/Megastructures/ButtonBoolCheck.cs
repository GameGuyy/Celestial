using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBoolCheck : MonoBehaviour 
{
	BuilderChecker buildercheck;
	Button currentButton;

	void Start () 
	{
		buildercheck = GameObject.Find ("Main Camera").GetComponent<BuilderChecker> ();
		currentButton = gameObject.GetComponent<Button> ();
	}

	void Update () 
	{
		if (buildercheck.BuilderBusy == true) 
		{
			currentButton.enabled = false;
		} 
		else if (buildercheck.BuilderBusy == false) 
		{
			currentButton.enabled = true;
		}
	}
}
