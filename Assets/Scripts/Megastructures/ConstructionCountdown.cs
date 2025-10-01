using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionCountdown : MonoBehaviour
{
    public float timer;
    public bool TimerOn = false;
    public bool startCollecting;
	public Text timerText;
	BuilderChecker buildercheck;
    // GameObject MegastructuresPanel;
    public bool Construction, UpdateS, Research;
    GameObject NotificationPanel;
    Text NotificationText1, NotificationText2;
    GameObject ObjectivesButton, ResetButton;
    SurfaceUI surfaceUI;

    private void Start()
    {
        surfaceUI = GameObject.Find("Main Camera").GetComponent<SurfaceUI>();
        ObjectivesButton = GameObject.Find("Objectives");
        ResetButton = GameObject.Find("ResetButton");
		buildercheck = GameObject.Find ("Main Camera").GetComponent<BuilderChecker> ();
        NotificationPanel = GameObject.Find("NotificationPanel");
        NotificationText1 = NotificationPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        NotificationText2 = NotificationPanel.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        timer = gameObject.GetComponent<BaseMegastructure>().timetaken;
       // MegastructuresPanel = GameObject.Find("MegaStructures");
    }

    void Update ()
    {
		if(TimerOn)
        {
            surfaceUI.BuilderBusy = true;
			timerText.gameObject.SetActive (true);
			timerText.text = "" + (int)timer;
            timer -= Time.deltaTime;
           // MegastructuresPanel.SetActive(false);
            if(timer <= 0)
            {
                //structureComplete
				buildercheck.BuilderBusy = false;
                startCollecting = true ;
				timerText.gameObject.SetActive (false);
               // MegastructuresPanel.SetActive(true);
                if (UpdateS == true)
                {
                    Updated();
                }
                if (Research == true)
                {
                    Researched();
                }
                if (Construction == true)
                {
                    Constructed();
                }
                surfaceUI.BuilderBusy = false;
                TimerOn = false;
            }
        }
	}

    public void StructureComplete()
    {
        //Take values from BaseMegastructure Class and User Prefs 
    }

    void Updated()
    {
        ObjectivesButton.SetActive(false);
        ResetButton.SetActive(false);
        NotificationText1.text = "Structure has been Updated.";
        NotificationText2.text = "";
        NotificationPanel.GetComponent<Animator>().enabled = true;
        NotificationPanel.GetComponent<Animator>().SetBool("Down", true);
        UpdateS = false;
    }

    void Researched()
    {
        ObjectivesButton.SetActive(false);
        ResetButton.SetActive(false);
        NotificationText1.text = "Structure has been Researched.";
        NotificationText2.text = "";
        NotificationPanel.GetComponent<Animator>().enabled = true;
        NotificationPanel.GetComponent<Animator>().SetBool("Down", true);
        Research = false;
    }

    void Constructed()
    {
        ObjectivesButton.SetActive(false);
        ResetButton.SetActive(false);
        NotificationText1.text = "Structure Construction has completed.";
        NotificationText2.text = "";
        NotificationPanel.GetComponent<Animator>().enabled = true;
        NotificationPanel.GetComponent<Animator>().SetBool("Down", true);
        Construction = false;
    }
}
