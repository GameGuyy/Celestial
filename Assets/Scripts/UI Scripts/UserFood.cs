using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserFood : MonoBehaviour
{
    Text food;
	void Start ()
    {
        food = gameObject.GetComponent<Text>();

        if(PlayerPrefs.HasKey("UserFood"))
        {
            food.text = "" + PlayerPrefs.GetInt("UserFood");
        }
        else
        {
            food.text = "0";
        }
	}

	void Update ()
    {
        if (PlayerPrefs.HasKey("UserFood"))
        {
            food.text = "" + PlayerPrefs.GetInt("UserFood");
        }
    }
}
