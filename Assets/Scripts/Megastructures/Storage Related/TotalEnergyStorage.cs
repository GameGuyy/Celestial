using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalEnergyStorage : MonoBehaviour
{
    public int totalCapacity;

    void Start ()
    {
        if (PlayerPrefs.HasKey("UserEnergyCapacity"))
        {
            totalCapacity = PlayerPrefs.GetInt("UserEnergyCapacity");
        }
        else
        {
            totalCapacity = 50000;
            PlayerPrefs.SetInt("UserEnergyCapacity", totalCapacity);
        }
    }

    public void AddToStorage(int valueadded)
    {
        totalCapacity += valueadded;
        PlayerPrefs.SetInt("UserEnergyCapacity", totalCapacity);
    }
}
