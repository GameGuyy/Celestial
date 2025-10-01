using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDeductor : MonoBehaviour 
{
	public int population;
	public int rate = 1;
	public float timer;
	public int userfood;
	public bool DeductEnergy;

	void Start ()
	{

	}

	void Update ()
	{
		population = PlayerPrefs.GetInt ("MarsPopulation");
		if (population > 0) 
		{
			userfood = PlayerPrefs.GetInt ("UserFood");
			if (userfood > 0) 
			{
				timer += Time.deltaTime;
				if (timer >= 60f) 
				{
					userfood -= (rate * population);
					PlayerPrefs.SetInt ("UserFood", userfood);
					timer = 0;
				}
			}
		}
	}

}
