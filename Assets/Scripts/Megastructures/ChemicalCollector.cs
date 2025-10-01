using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemicalCollector : MonoBehaviour
{
    public int chemicalrate;
    public int capacity;
    public int collected;
    int userchemical;
    int total;
    public float timeCount;
    ConstructionCountdown complete;
	bool showButton;
	public GameObject CollectButton;
    public Text DisplayText;
	public bool StartDisplaying;
    Text ChemicalText;

    void Start()
    {
        complete = gameObject.GetComponent<ConstructionCountdown>();
        ChemicalText = GameObject.Find("UserChemical").GetComponent<Text>();
        DisplayText = GameObject.Find("MegaStructureInfo").transform.GetChild(4).GetComponent<Text>();
        DisplayText.text = "Capacity: " + collected + " / " + capacity;
    }

    void Update()
    {
        int usertotal = PlayerPrefs.GetInt("UserChemical");
        int totalstorage = PlayerPrefs.GetInt("UserChemicalCapacity");
        if (usertotal >= totalstorage)
        {
            complete.startCollecting = false;
        }
        else if (usertotal < totalstorage)
        {
            complete.startCollecting = true;
        }

        if (complete.startCollecting)
        {
            if (collected < capacity)
            {
                timeCount += Time.deltaTime;
                if (timeCount >= 60)
                {
                    if ((collected + chemicalrate) > capacity)
                    {
                        collected = capacity;
                        DisplayText.text = "Capacity: " + collected + " / " + capacity;
                    }
                    else
                    {
                        collected += chemicalrate;
                        DisplayText.text = "Capacity: " + collected + " / " + capacity;
                    }
                    timeCount = 0;

                }
            }
            else
            {
                //complete.startCollecting = false;
				timeCount = 0;
            }

			if (collected >= chemicalrate) 
			{
				showButton = true;
			}



			if (showButton) 
			{
				CollectButton.SetActive (true);
				showButton = false;
			}

			if (StartDisplaying) 
			{
				if (userchemical < total) 
				{
                    userchemical+=2;
                    ChemicalText.text = "" + userchemical;
                    PlayerPrefs.SetInt("UserChemical", userchemical);
                }

				if (userchemical == total) 
				{
                    ChemicalText.text = "" + total;
                    PlayerPrefs.SetInt("UserChemical", total);
					StartDisplaying = false;
				}
			}
        }
    }

	void OnMouseDown()
	{
		CollectChemical ();
	}

	public void CollectChemical()
	{
		CollectButton.SetActive (false);
        if (PlayerPrefs.HasKey("MarsChemicalsExtracted"))
        {
            int number = PlayerPrefs.GetInt("MarsChemicalsExtracted");
            number += collected;
            PlayerPrefs.SetInt("MarsChemicalsExtracted", number);
        }
        else
        {
            PlayerPrefs.SetInt("MarsChemicalsExtracted", collected);
        }
        userchemical = PlayerPrefs.GetInt("UserChemical");
        total = userchemical + collected;
        collected = 0;
        DisplayText.text = "Capacity: " + collected + " / " + capacity;
        StartDisplaying = true;
	}
}
