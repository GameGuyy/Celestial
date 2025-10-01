using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserCosmicCash : MonoBehaviour
{
    Text cosmiccash;
    void Start()
    {
        cosmiccash = gameObject.GetComponent<Text>();

        if (PlayerPrefs.HasKey("UserCosmicCash"))
        {
            cosmiccash.text = "" + PlayerPrefs.GetInt("UserCosmicCash");
        }
        else
        {
            cosmiccash.text = "0";
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("UserCosmicCash"))
        {
            cosmiccash.text = "" + PlayerPrefs.GetInt("UserCosmicCash");
        }
    }
}
