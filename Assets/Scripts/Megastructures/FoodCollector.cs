using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCollector : MonoBehaviour
{
    public int foodrate;
    public int capacity;
    public int collected;
    int userfood, total;
    float timeCount;
    ConstructionCountdown complete;
	bool showButton;
    bool StartDisplaying;
	public GameObject CollectButton;
    public Text DisplayText;
    Text FoodText;


    void Start()
    {
        complete = gameObject.GetComponent<ConstructionCountdown>();
        FoodText = GameObject.Find("UserFood").GetComponent<Text>();
        DisplayText = GameObject.Find("MegaStructureInfo").transform.GetChild(4).GetComponent<Text>();
        DisplayText.text = "Capacity: " + collected + " / " + capacity;
    }

    void Update()
    {
        int usertotal = PlayerPrefs.GetInt("UserFood");
        int totalstorage = PlayerPrefs.GetInt("UserFoodCapacity");
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
                    if ((collected + foodrate) > capacity)
                    {
                        collected = capacity;
                        DisplayText.text = "Capacity: " + collected + " / " + capacity;
                    }
                    else
                    {
                        collected += foodrate;
                        DisplayText.text = "Capacity: " + collected + " / " + capacity;
                    }
                    timeCount = 0;

                }
            }
            else
            {
                complete.startCollecting = false;
            }

			if (collected >= foodrate) 
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
                if (userfood < total)
                {
                    userfood++;
                    FoodText.text = "" + userfood;
                    PlayerPrefs.SetInt("UserFood", userfood);
                }

                if (userfood == total)
                {
                    FoodText.text = "" + total;
                    PlayerPrefs.SetInt("UserFood", total);
                    collected = 0;
                    StartDisplaying = false;
                }
            }
        }
    }

	public void CollectFood()
	{
		userfood = PlayerPrefs.GetInt ("UserFood");
        if (PlayerPrefs.HasKey("MarsFoodProduced"))
        {
            int number = PlayerPrefs.GetInt("MarsFoodProduced");
            number += collected;
            PlayerPrefs.SetInt("MarsFoodProduced", number);
        }
        else
        {
            PlayerPrefs.SetInt("MarsFoodProduced", collected);
        }
        total = userfood + collected;
        CollectButton.SetActive(false);
        collected = 0;
        DisplayText.text = "Capacity: " + collected + " / " + capacity;
    }
}
