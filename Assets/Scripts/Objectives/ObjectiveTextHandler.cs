using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTextHandler : MonoBehaviour 
{
    public Text ObjectiveText1, ObjectiveText2;
    public Image ObjectiveTick1, ObjectiveTick2;
    public Sprite TickImage, NoTickImage;
    ObjectivesHandler objhandler;
    public int objnumber1, objnumber2;
    public string obj1pref, obj2pref;
    public bool checker;
    public bool CheckNotif;

    private void Awake()
    {
        objhandler = GameObject.Find("Canvas").GetComponent<ObjectivesHandler>();
    }

    void Start () 
	{
        StartCoroutine(CheckPref());
	}

    IEnumerator CheckPref()
    {
        yield return new WaitForSeconds(2);
        objnumber1 = objhandler.ObjectivesDone + 1;
        objnumber2 = objhandler.ObjectivesDone + 2;
        obj1pref = "Objective" + objnumber1 + "Done";
        obj2pref = "Objective" + objnumber2 + "Done";
        checker = true;
    }

    private void Update()
    {
        if(checker == true)
        {
            if (PlayerPrefs.HasKey(obj1pref))
            {
                ObjectiveTick1.sprite = TickImage;
            }
            else
            {
                ObjectiveTick1.sprite = NoTickImage;
            }

            if (PlayerPrefs.HasKey(obj2pref))
            {
                ObjectiveTick2.sprite = TickImage;
            }
            else
            {
                ObjectiveTick2.sprite = NoTickImage;
            }

            if(PlayerPrefs.HasKey(obj1pref) && PlayerPrefs.HasKey(obj2pref))
            {
                if(CheckNotif == true)
                {
                    objnumber1 = objhandler.ObjectivesDone + 1;
                    objnumber2 = objhandler.ObjectivesDone + 2;
                    obj1pref = "Objective" + objnumber1 + "Done";
                    obj2pref = "Objective" + objnumber2 + "Done";
                    ObjectiveText1.text = objhandler.Objectives[objnumber1 - 1];
                    ObjectiveText2.text = objhandler.Objectives[objnumber2 - 1];
                    objhandler.NotificationsUnlocked();
                }
            }
        }
    }

}
