using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrosionHandler : MonoBehaviour 
{
	public int corrosionrate;
	ConstructionCountdown timerScript;
	BaseMegastructure mainScript;
	public float timer;

	void Start () 
	{
		timerScript = gameObject.GetComponent<ConstructionCountdown> ();
		mainScript = gameObject.GetComponent<BaseMegastructure> ();
	}

	void Update () 
	{
		if (timerScript.startCollecting == true) 
		{
			timer += Time.deltaTime;
			if (timer >= 60) 
			{
				mainScript.durability -= corrosionrate;
                PlayerPrefs.SetInt(mainScript.structuredurability, mainScript.durability);
				if (mainScript.durability <= 0) 
				{
					mainScript.durability = 0;
					timerScript.startCollecting = false;
				}
                timer = 0;
			}
		}
	}
}
