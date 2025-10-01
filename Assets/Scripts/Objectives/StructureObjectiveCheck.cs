using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureObjectiveCheck : MonoBehaviour
{
    public int objectivenumber;
    public int structurelevelcheck;
    BaseMegastructure structureCheck;
    string prefcheck;
    public bool objdonecheck;
    ConstructionCountdown timer;
    ObjectivesHandler objCheck;
    int check;

	void Start ()
    {
        timer = gameObject.GetComponent<ConstructionCountdown>();
        structureCheck = gameObject.GetComponent<BaseMegastructure>();
        prefcheck = "Objective" + objectivenumber + "Done";
        check = PlayerPrefs.GetInt(structureCheck.structurelevelsave);
        objCheck = GameObject.Find("Canvas").GetComponent<ObjectivesHandler>();
        StartCoroutine(WaitAndCheck());
    }

    IEnumerator WaitAndCheck()
    {
        yield return new WaitForSeconds(2);
        if (objCheck.ObjectivesDone == 2 && structureCheck.structurename == "Command Centre")
        {
            objectivenumber = 3;
            structurelevelcheck = 2;
        }
        else if (objCheck.ObjectivesDone == 9 && structureCheck.structurename == "Greenhouse")
        {
            objectivenumber = 10;
            structurelevelcheck = 2;
        }
        else if (objCheck.ObjectivesDone == 11 && structureCheck.structurename == "Habitat House")
        {
            objectivenumber = 12;
            structurelevelcheck = 2;
        }
        else if (objCheck.ObjectivesDone == 13 && structureCheck.structurename == "Medi House")
        {
            objectivenumber = 14;
            structurelevelcheck = 2;
        }
    }

	void Update ()
    {
        if(timer.TimerOn == false)
        {
            if (PlayerPrefs.HasKey(structureCheck.structuresave))
            {
                check = PlayerPrefs.GetInt(structureCheck.structurelevelsave);
                if (check == structurelevelcheck)
                {
                    if (!PlayerPrefs.HasKey(prefcheck))
                    {
                        PlayerPrefs.SetInt(prefcheck, 1);
                        objdonecheck = true;
                        if (objdonecheck == true)
                        {
                            int objdone = PlayerPrefs.GetInt("ObjectivesDone");
                            objdone += 1;
                            PlayerPrefs.SetInt("ObjectivesDone", objdone);
                            objdonecheck = false;
                        }
                        if (structureCheck.structurename == "Command Centre" && objectivenumber == 1)
                        {
                            objectivenumber = 3;
                            structurelevelcheck = 2;
                            prefcheck = "Objective" + objectivenumber + "Done";
                        }
                        if (structureCheck.structurename == "Greenhouse" && objectivenumber == 1)
                        {
                            objectivenumber = 10;
                            structurelevelcheck = 2;
                            prefcheck = "Objective" + objectivenumber + "Done";
                        }
                        if (structureCheck.structurename == "Habitat House" && objectivenumber == 1)
                        {
                            objectivenumber = 12;
                            structurelevelcheck = 2;
                            prefcheck = "Objective" + objectivenumber + "Done";
                        }
                        if (structureCheck.structurename == "Medi House" && objectivenumber == 1)
                        {
                            objectivenumber = 14;
                            structurelevelcheck = 2;
                            prefcheck = "Objective" + objectivenumber + "Done";
                        }

                    }
                }
            }
        }
	}
}
