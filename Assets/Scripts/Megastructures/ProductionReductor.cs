using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionReductor : MonoBehaviour
{
    BaseMegastructure structureinfo;
    ChemicalCollector chemcollect;
    bool chemicalCheck;

	void Start ()
    {
        structureinfo = gameObject.GetComponent<BaseMegastructure>();
        if(gameObject.tag == "Chemical")
        {
            chemcollect = gameObject.GetComponent<ChemicalCollector>();
        }
	}
	
	void Update ()
    {
		if(chemicalCheck)
        {
            if(structureinfo.durability == 0)
            {
                chemcollect.capacity = chemcollect.capacity - (int)((75 * chemcollect.capacity) / 100);
                structureinfo.capacity = chemcollect.capacity;
            }
            else
            {
                structureinfo.capacity = structureinfo.ogcapacity;
                chemcollect.capacity = structureinfo.capacity;
            }
        }
	}
}
