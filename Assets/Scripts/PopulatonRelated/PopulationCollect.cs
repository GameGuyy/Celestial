using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationCollect : MonoBehaviour
{
    public int capacity;
    ConstructionCountdown countdown;

	void Start ()
    {
        countdown = gameObject.GetComponent<ConstructionCountdown>();
		int pop = PlayerPrefs.GetInt ("MarsPopulation");
		pop += capacity;
		PlayerPrefs.SetInt ("MarsPopulation", pop);
		if (!PlayerPrefs.HasKey ("MarsPopulationStart")) 
		{
			PlayerPrefs.SetInt ("MarsPopulationStart",1);
		}
	}
	
	void Update ()
    {
	}
}
