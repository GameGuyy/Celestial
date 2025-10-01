using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthRateHandler : MonoBehaviour 
{
	public int rate = 1;
	public int capacity = 500;
	public int population;
	public float timer;
	public bool BirthOn;

	void Start () 
	{
		
	}

	void Update () 
	{
		if (PlayerPrefs.HasKey ("MarsPopulationStart")) 
		{
			population = PlayerPrefs.GetInt ("MarsPopulation");
			if (population < capacity) 
			{
				BirthOn = true;
			}

			if (BirthOn) 
			{
				timer += Time.deltaTime;
				if (timer >= 60f) 
				{
					population += rate;
					PlayerPrefs.SetInt ("MarsPopulation", population);
					timer = 0;
				}
			}
		}
	}
}
