using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyCollector : MonoBehaviour
{
    public int technologyrate;
    public int collected;
    public float timeCount;
    ConstructionCountdown complete;

    void Start()
    {
        complete = gameObject.GetComponent<ConstructionCountdown>();
    }

    void Update()
    {
        if (complete.startCollecting)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= 60f)
            {
                //                collected += technologyrate;
                int usertechnology = PlayerPrefs.GetInt("UserTechnology");
                usertechnology += technologyrate;
                if (PlayerPrefs.HasKey("MarsContributionToTechnology"))
                {
                    int number = PlayerPrefs.GetInt("MarsContributionToTechnology");
                    number += technologyrate;
                    PlayerPrefs.SetInt("MarsContributionToTechnology", number);
                }
                else
                {
                    PlayerPrefs.SetInt("MarsContributionToTechnology", technologyrate);
                }
                PlayerPrefs.SetInt("UserTechnology", usertechnology);
                timeCount = 0;
            }
        }
    }
}
