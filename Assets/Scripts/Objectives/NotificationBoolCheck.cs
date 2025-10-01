using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationBoolCheck : MonoBehaviour
{
    ObjectiveTextHandler objTextHandler;

    private void Start()
    {
        objTextHandler = GameObject.Find("Objectives").GetComponent<ObjectiveTextHandler>();
    }

    void SetNotifOff()
    {
        objTextHandler.CheckNotif = true;
    }
}
