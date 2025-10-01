using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureColliderChecker : MonoBehaviour
{
    SurfaceUI BoolChecker;
    BoxCollider StructureCollider;

	void Start ()
    {
        BoolChecker = GameObject.Find("Main Camera").GetComponent<SurfaceUI>();
        StructureCollider = gameObject.GetComponent<BoxCollider>();
	}
	
	void Update ()
    {
		if(BoolChecker.ColliderOff == true)
        {
            StructureCollider.enabled = false;
        }
        else if(BoolChecker.ColliderOff == false)
        {
            StructureCollider.enabled = true;
        }
	}
}
