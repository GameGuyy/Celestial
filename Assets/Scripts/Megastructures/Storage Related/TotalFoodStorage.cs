using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalFoodStorage : MonoBehaviour
{
    public int totalCapacity;

	void Start ()
    {
        if (PlayerPrefs.HasKey("UserFoodCapacity"))
        {
            totalCapacity = PlayerPrefs.GetInt("UserFoodCapacity");
        }
        else
        {
            totalCapacity = 50000;
            PlayerPrefs.SetInt("UserFoodCapacity", totalCapacity);
        }
    }

    public void AddToStorage(int valueadded)
    {
        totalCapacity += valueadded;
        PlayerPrefs.SetInt("UserFoodCapacity", totalCapacity);
    }

}
