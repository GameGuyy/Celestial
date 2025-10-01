using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRateHandler : MonoBehaviour 
{
	public int rate = 1;
	public int population;
	public bool DeathOn;
	public float timer;

	void Start () 
	{
		
	}

	void Update () 
	{
		if (PlayerPrefs.HasKey ("MarsPopulationStart")) 
		{
			population = PlayerPrefs.GetInt ("MarsPopulation");
			if (population > 0) 
			{
				DeathOn = true;
			}

			if (DeathOn == true) 
			{
				timer += Time.deltaTime;
				if (timer >= 120f) 
				{
					population -= rate;
					PlayerPrefs.SetInt ("MarsPopulation", population);
					timer = 0;
				}
			}
		}
	}
}
