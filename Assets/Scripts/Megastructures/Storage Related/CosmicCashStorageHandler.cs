using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicCashStorageHandler : MonoBehaviour
{

    public int structurestorage;
    TotalCosmicCashStorage totalstorage;

    void Start()
    {
        totalstorage = GameObject.Find("Canvas").GetComponent<TotalCosmicCashStorage>();
        totalstorage.AddToStorage(structurestorage);
    }

    void Update()
    {

    }
}
