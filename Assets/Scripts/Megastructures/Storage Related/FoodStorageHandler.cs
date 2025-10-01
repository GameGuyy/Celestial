using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStorageHandler : MonoBehaviour
{

    public int structurestorage;
    TotalFoodStorage totalstorage;

    void Start()
    {
        totalstorage = GameObject.Find("Canvas").GetComponent<TotalFoodStorage>();
        totalstorage.AddToStorage(structurestorage);
    }

    void Update()
    {

    }
}
