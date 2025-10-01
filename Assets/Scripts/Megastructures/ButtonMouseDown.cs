using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMouseDown : MonoBehaviour 
{
    public ChemicalCollector collect;
    public EnergyCollector collect2;
    public FoodCollector collect3;
    public CosmicCashCollector collect4;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseDown()
	{
        if(gameObject.tag == "Chemical")
        {
            collect.CollectChemical();
        }
        if (gameObject.tag == "Food")
        {
            collect3.CollectFood();
        }
        if (gameObject.tag == "Energy")
        {
            collect2.CollectEnergy();
        }
        if (gameObject.tag == "CosmicCash")
        {
            collect4.CollectCosmicCash();
        }
    }
}
