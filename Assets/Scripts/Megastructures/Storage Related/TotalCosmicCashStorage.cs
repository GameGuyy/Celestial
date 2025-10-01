using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCosmicCashStorage : MonoBehaviour
{
    public int totalCapacity;

    void Start ()
    {
        if (PlayerPrefs.HasKey("UserCosmicCashCapacity"))
        {
            totalCapacity = PlayerPrefs.GetInt("UserCosmicCashCapacity");
        }
        else
        {
            totalCapacity = 50000;
            PlayerPrefs.SetInt("UserCosmicCashCapacity", totalCapacity);
        }
    }

    public void AddToStorage(int valueadded)
    {
        totalCapacity += valueadded;
        PlayerPrefs.SetInt("UserCosmicCashCapacity", totalCapacity);
    }
}
