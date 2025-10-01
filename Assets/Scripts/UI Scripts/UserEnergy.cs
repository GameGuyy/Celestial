using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserEnergy : MonoBehaviour
{
    Text energy;
    void Start()
    {
        energy = gameObject.GetComponent<Text>();

        if (PlayerPrefs.HasKey("UserEnergy"))
        {
            energy.text = "" + PlayerPrefs.GetInt("UserEnergy");
        }
        else
        {
            energy.text = "0";
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("UserEnergy"))
        {
            energy.text = "" + PlayerPrefs.GetInt("UserEnergy");
        }
    }
}
