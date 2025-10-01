using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCollector : MonoBehaviour
{
    public int energyrate;
    public int capacity;
    public int collected;
    public float timeCount;
    int userenergy, total;
    bool startCollecting;
	bool showButton;
    bool StartDisplaying;
	public GameObject CollectButton;
    public Text DisplayText;
	ConstructionCountdown complete;
    Text EnergyText;
   
	void Start ()
    {
        //startCollecting = true;
		complete = gameObject.GetComponent<ConstructionCountdown>();
        EnergyText = GameObject.Find("UserEnergy").GetComponent<Text>();
        DisplayText = GameObject.Find("MegaStructureInfo").transform.GetChild(4).GetComponent<Text>();
        DisplayText.text = "Capacity: " + collected + " / " + capacity;
    }

	void Update ()
    {
        int usertotal = PlayerPrefs.GetInt("UserEnergy");
        int totalstorage = PlayerPrefs.GetInt("UserEnergyCapacity");
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
				timeCount += Time.deltaTime;
				if(timeCount >= 60)
				{
					if((collected + energyrate) > capacity)
					{
						collected = capacity;
                        DisplayText.text = "Capacity: " + collected + " / " + capacity;
                    }
					else
					{
						collected += energyrate;
                        DisplayText.text = "Capacity: " + collected + " / " + capacity;
                    }
					timeCount = 0;

				}

				if (collected >= energyrate) 
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
                    if (userenergy < total)
                    {
                        userenergy++;
                        EnergyText.text = "" + userenergy;
                        PlayerPrefs.SetInt("UserEnergy", userenergy);
                    }

                    if (userenergy == total)
                    {
                        EnergyText.text = "" + total;
                        PlayerPrefs.SetInt("UserEnergy", total);
                        collected = 0;
                        StartDisplaying = false;
                    }
                }

        }
	}

	public void CollectEnergy()
	{
		userenergy = PlayerPrefs.GetInt ("UserEnergy");
        if (PlayerPrefs.HasKey("MarsEnergyHarnessed"))
        {
            int number = PlayerPrefs.GetInt("MarsEnergyHarnessed");
            number += collected;
            PlayerPrefs.SetInt("MarsEnergyHarnessed", number);
        }
        else
        {
            PlayerPrefs.SetInt("MarsEnergyHarnessed", collected);
        }

        if (PlayerPrefs.HasKey("MarsContributionToEnergy"))
        {
            int number = PlayerPrefs.GetInt("MarsContributionToEnergy");
            number += collected;
            PlayerPrefs.SetInt("MarsContributionToEnergy", number);
        }
        else
        {
            PlayerPrefs.SetInt("MarsContributionToEnergy", collected);
        }
        total = userenergy + collected;
        CollectButton.SetActive (false);
        collected = 0;
        DisplayText.text = "Capacity: " + collected + " / " + capacity;
        StartDisplaying = true;
    }
}
