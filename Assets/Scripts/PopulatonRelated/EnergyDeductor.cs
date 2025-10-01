using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDeductor : MonoBehaviour
{
	public int population;
	public int rate = 1;
	public float timer;
    public int collect;
	public int userenergy;
	public bool DeductEnergy;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		population = PlayerPrefs.GetInt ("MarsPopulation");
		if (population > 0) 
		{
			userenergy = PlayerPrefs.GetInt ("UserEnergy");
			if (userenergy > 0) 
			{
				timer += Time.deltaTime;
				if (timer >= 60f) 
				{
					userenergy -= (rate * population);
                    collect += rate;
                    if (PlayerPrefs.HasKey("MarsEnergyUtilised"))
                    {
                        int number = PlayerPrefs.GetInt("MarsEnergyUtilised");
                        number += collect;
                        PlayerPrefs.SetInt("MarsEnergyUtilised", number);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("MarsEnergyUtilised", collect);
                    }
                    PlayerPrefs.SetInt ("UserEnergy", userenergy);
					timer = 0;
				}
			}
		}
	}
}
