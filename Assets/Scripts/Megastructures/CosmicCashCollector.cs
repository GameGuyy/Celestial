using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CosmicCashCollector : MonoBehaviour
{
    public int cosmiccashrate;
    public int capacity;
    public int collected;
    int usercosmiccash, total;
    float timeCount;
    ConstructionCountdown complete;
	bool showButton;
	public GameObject CollectButton;
    public Text DisplayText;
    Text CosmicCashText;
    bool StartDisplaying;

    void Start()
    {
        complete = gameObject.GetComponent<ConstructionCountdown>();
        CosmicCashText = GameObject.Find("UserCosmicCash").GetComponent<Text>();
        DisplayText = GameObject.Find("MegaStructureInfo").transform.GetChild(4).GetComponent<Text>();
        DisplayText.text = "Capacity: " + collected + " / " + capacity;
    }

    void Update()
    {
        int usertotal = PlayerPrefs.GetInt("UserCosmicCash");
        int totalstorage = PlayerPrefs.GetInt("UserCosmicCashCapacity");
        if(usertotal >= totalstorage)
        {
            complete.startCollecting = false;
        }
        else if(usertotal < totalstorage)
        {
            complete.startCollecting = true;
        }

        if (complete.startCollecting)
        {
            timeCount += Time.deltaTime;
			if (timeCount >= 60)
			{
				if ((collected + cosmiccashrate) > capacity) 
				{
					collected = capacity;
                    DisplayText.text = "Capacity: " + collected + " / " + capacity;
                } 
				else 
				{
					collected += cosmiccashrate;
                    DisplayText.text = "Capacity: " + collected + " / " + capacity;
                }
				timeCount = 0;

			}

			if (collected >= cosmiccashrate) 
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
                if (usercosmiccash < total)
                {
                    usercosmiccash++;
                    CosmicCashText.text = "" + usercosmiccash;
                    PlayerPrefs.SetInt("UserCosmicCash", usercosmiccash);
                }

                if (usercosmiccash == total)
                {
                    CosmicCashText.text = "" + total;
                    PlayerPrefs.SetInt("UserCosmicCash", total);
                    collected = 0;
                    StartDisplaying = false;
                }
            }
        }
    }

	public void CollectCosmicCash()
	{
		usercosmiccash = PlayerPrefs.GetInt ("UserCosmicCash");
        total = usercosmiccash + collected;
		collected = 0;
        DisplayText.text = "Capacity: " + collected + " / " + capacity;
        CollectButton.SetActive(false);
        StartDisplaying = true;
	}
}
