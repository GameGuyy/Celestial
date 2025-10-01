using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalChemicalStorage : MonoBehaviour
{
    public int totalCapacity;

    void Start ()
    {
        if (PlayerPrefs.HasKey("UserChemicalCapacity"))
        {
            totalCapacity = PlayerPrefs.GetInt("UserChemicalCapacity");
        }
        else
        {
            totalCapacity = 50000;
            PlayerPrefs.SetInt("UserChemicalCapacity", totalCapacity);
        }
    }

    public void AddToStorage(int valueadded)
    {
        totalCapacity += valueadded;
        PlayerPrefs.SetInt("UserChemicalCapacity", totalCapacity);
    }
}
