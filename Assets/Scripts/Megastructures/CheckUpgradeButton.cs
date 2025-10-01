using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckUpgradeButton : MonoBehaviour
{
    GameObject UpdateButton;
    BaseMegastructure megastructures;
    public bool Checker;

	void Start ()
    {
        UpdateButton = GameObject.Find("UpgradeButton");
        megastructures = gameObject.GetComponent<BaseMegastructure>();
        StartCoroutine(WaitAndStartCheck());
	}

    IEnumerator WaitAndStartCheck()
    {
        yield return new WaitForSeconds(2);
        Checker = true;
    }
	
	void Update ()
    {
		if(Checker == true)
        {
            if(PlayerPrefs.HasKey(megastructures.structurelevelsave))
            {
                int level = PlayerPrefs.GetInt(megastructures.structurelevelsave);
                if(level >= 3)
                {
                    UpdateButton.SetActive(false);
                }
                else
                {
                    UpdateButton.SetActive(true);
                }
            }
        }
	}
}
