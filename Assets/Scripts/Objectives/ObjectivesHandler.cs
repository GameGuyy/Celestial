using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesHandler : MonoBehaviour 
{
    public List<string> Objectives;
    public Text NotificationText1 , NotificationText2;
    public GameObject NotificationPanel;
    public int ObjectivesDone;
    public Text ObjectiveText1, ObjectiveText2;
	public GameObject ObjectivePanel;
    public GameObject ObjectivesButton, ResetButton;
    SurfaceUI BoolChecker;

    void Start () 
	{
        //PlayerPrefs.DeleteKey("NewPlayer");
        //PlayerPrefs.DeleteAll();
        BoolChecker = GameObject.Find("Main Camera").GetComponent<SurfaceUI>();
        if (!PlayerPrefs.HasKey("NewPlayer"))
        {
            ObjectivesDone = 0;
            PlayerPrefs.SetInt("ObjectivesDone", 0);
            NotificationText1.text = "Please Check the Objectives Panel.";
            NotificationText2.text = ""; 
            NotificationPanel.GetComponent<Animator>().enabled = true;
            NotificationPanel.GetComponent<Animator>().SetBool("Down", true);
			ObjectivesButton.GetComponent<Animator> ().enabled = true;
            ObjectiveText1.text = Objectives[ObjectivesDone];
            ObjectiveText2.text = Objectives[ObjectivesDone + 1];
            PlayerPrefs.SetInt("NewPlayer", 1); 
        }
        else
        {
            ObjectivesDone = PlayerPrefs.GetInt("ObjectivesDone");
            if(ObjectivesDone == 0)
            {
                ObjectiveText1.text = Objectives[0];
                ObjectiveText2.text = Objectives[1];
            }
            else
            {
                if (ObjectivesDone / 2 > 0)
                {
                    ObjectiveText1.text = Objectives[ObjectivesDone];
                    ObjectiveText2.text = Objectives[ObjectivesDone + 1];
                }
                else
                {
                    ObjectiveText1.text = Objectives[ObjectivesDone - 1];
                    ObjectiveText2.text = Objectives[ObjectivesDone];
                }
            }
           
        }
	}

    public void NotificationsUnlocked()
    {
        NotificationText1.text = "Objectives Complete! New Objectives Unlocked.";
        NotificationText2.text = "";
        BoolChecker.ColliderOff = true;
        NotificationPanel.GetComponent<Animator>().enabled = true;
        NotificationPanel.GetComponent<Animator>().SetBool("Down", true);
        ObjectivesButton.GetComponent<Animator>().enabled = true;
		ObjectivePanel.GetComponent<Animator> ().enabled = true;
    }

    public void CloseNotification()
    {
        ObjectivesButton.SetActive(true);
        ResetButton.SetActive(true);
        BoolChecker.ColliderOff = false;
        NotificationPanel.GetComponent<Animator>().enabled = true;
        NotificationPanel.GetComponent<Animator>().SetBool("Down", false);
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("ObjectivesDone") % 2 == 0)
        {
           ObjectivesDone = PlayerPrefs.GetInt("ObjectivesDone");
        }
    }
}
