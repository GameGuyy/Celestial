using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButtonCheck : MonoBehaviour 
{
	BuilderChecker builderCheck;
	Button button;

	void Start()
	{
		builderCheck = GameObject.Find ("Main Camera").GetComponent<BuilderChecker> ();
		button = gameObject.GetComponent<Button> ();
	}

	void Update () 
	{
		if (builderCheck.BuilderBusy == true) 
		{
			button.enabled = false;
		} 
		else if(builderCheck.BuilderBusy == false)
		{
			button.enabled = true;
		}
	}
}
