using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStorageHandler : MonoBehaviour
{
    public int structurestorage;
    TotalEnergyStorage totalstorage;

    void Start()
    {
        totalstorage = GameObject.Find("Canvas").GetComponent<TotalEnergyStorage>();
        totalstorage.AddToStorage(structurestorage);
    }

    void Update()
    {

    }
}
