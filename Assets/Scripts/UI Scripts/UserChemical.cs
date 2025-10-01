using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserChemical : MonoBehaviour
{
    Text chemical;
    void Start()
    {
        chemical = gameObject.GetComponent<Text>();

        if (PlayerPrefs.HasKey("UserChemical"))
        {
            chemical.text = "" + PlayerPrefs.GetInt("UserChemical");
        }
        else
        {
            chemical.text = "0";
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("UserChemical"))
        {
            chemical.text = "" + PlayerPrefs.GetInt("UserChemical");
        }
    }
}
