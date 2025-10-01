using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResearchButton : MonoBehaviour
{
    GameObject ResearchButton;
    BaseMegastructure megastructures;
    public bool Checker;

    void Start()
    {
        ResearchButton = GameObject.Find("ResearchButton");
        megastructures = gameObject.GetComponent<BaseMegastructure>();
        StartCoroutine(WaitAndStartCheck());
    }

    IEnumerator WaitAndStartCheck()
    {
        yield return new WaitForSeconds(2);
        Checker = true;
    }

    void Update()
    {
        if (Checker == true)
        {
            if (PlayerPrefs.HasKey(megastructures.structureresearchlevel))
            {
                int level = PlayerPrefs.GetInt(megastructures.structureresearchlevel);
                if (level >= 3)
                {
                    ResearchButton.SetActive(false);
                }
                else
                {
                    ResearchButton.SetActive(true);
                }
            }
        }
    }
}
