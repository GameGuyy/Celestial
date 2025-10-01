using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserTechnoloogy : MonoBehaviour
{
    Text technology;
    void Start()
    {
        technology = gameObject.GetComponent<Text>();

        if (PlayerPrefs.HasKey("UserTechnology"))
        {
            technology.text = "" + PlayerPrefs.GetInt("UserTechnology");
        }
        else
        {
            technology.text = "0";
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("UserTechnology"))
        {
            technology.text = "" + PlayerPrefs.GetInt("UserTechnology");
        }
    }
}
