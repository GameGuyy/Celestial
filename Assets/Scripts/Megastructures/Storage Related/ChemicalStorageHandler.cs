using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalStorageHandler : MonoBehaviour
{
    public int structurestorage;
    TotalChemicalStorage totalstorage;

	void Start ()
    {
        totalstorage = GameObject.Find("Canvas").GetComponent<TotalChemicalStorage>();
        totalstorage.AddToStorage(structurestorage);
	}
	
	void Update ()
    {
		
	}
}
