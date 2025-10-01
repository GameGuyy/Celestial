using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionHandler : MonoBehaviour
{
    public int productionrate;
    public int capacity;
    public bool prodstart;
    public float prodtimer = 60f;
    public float collectiontimer;
    public int production;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(prodstart)
        {
            collectiontimer += Time.deltaTime;
            if(collectiontimer >= prodtimer)
            {
                //collection increase and timer reset
                collectiontimer = 0;
            }

            if(production >= capacity)
            {
                collectiontimer = 0;
                prodstart = false;
            }
        }
	}
}
