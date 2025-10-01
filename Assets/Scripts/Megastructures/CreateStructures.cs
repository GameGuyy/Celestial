using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStructures : MonoBehaviour
{
    public List<string> structurenames;
    public List<GameObject> structureprefs;
    public List<GameObject> structurescreated;
    ObjectivesHandler objHandler;
    ObjectiveTextHandler objTextHandler;

	void Start ()
    {
        objHandler = gameObject.GetComponent<ObjectivesHandler>();
        objTextHandler = GameObject.Find("Objectives").GetComponent<ObjectiveTextHandler>();
        CheckStructures();
	}

	void CheckStructures ()
    {
		for(int i = 0; i < structurenames.Count; i++)
        {
            if(PlayerPrefs.HasKey(structurenames[i]))
            {
                int counter = PlayerPrefs.GetInt(structurenames[i]);
                for(int j = 1; j <= counter; j++)
                {
                    string structuresave = structurenames[i] + counter;
                    string posxpref = structuresave + "x";
                    string posypref = structuresave + "y";
                    string poszpref = structuresave + "z";
                    float posx = PlayerPrefs.GetFloat(posxpref);
                    float posy = PlayerPrefs.GetFloat(posypref);
                    float posz = PlayerPrefs.GetFloat(poszpref);
                    Vector3 pos = new Vector3(posx, posy, posz);
                    GameObject create = Instantiate(structureprefs[i]);
                    create.transform.position = new Vector3(posx, posy, posz);
                    structurescreated.Add(create);
                    create.GetComponent<ConstructionCountdown>().startCollecting = true;
                }
            }
        }
	}

    public void DeleteStructures()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("UserData", 1);
        PlayerPrefs.SetInt("UserCosmicCash", 50000);
        PlayerPrefs.SetInt("UserFood", 50000);
        PlayerPrefs.SetInt("UserChemical", 50000);
        PlayerPrefs.SetInt("UserEnergy", 50000);
        PlayerPrefs.SetInt("UserTechnology", 50000);

        PlayerPrefs.SetInt("MarsData", 1);
        PlayerPrefs.SetInt("MarsCash", 0);
        PlayerPrefs.SetInt("MarsFood", 0);
        PlayerPrefs.SetInt("MarsChemical", 0);
        PlayerPrefs.SetInt("MarsTechnology", 0);
        PlayerPrefs.SetInt("MarsEnergy", 0);

        PlayerPrefs.SetInt("MarsHabitability", 28);
        PlayerPrefs.SetInt("MarsHostility", 72);
        PlayerPrefs.SetInt("MarsPopulation", 0);
        PlayerPrefs.SetInt("MarsPeoplePerArea", 0);
        PlayerPrefs.SetInt("MarsBirthrate", 0);
        PlayerPrefs.SetInt("MarsDeathrate", 0);
        PlayerPrefs.SetInt("MarsSurvivalrate", 0);
        PlayerPrefs.SetInt("MarsGenerations", 1);
        PlayerPrefs.SetInt("MarsContributionToEnergy", 0);
        PlayerPrefs.SetInt("MarsContributionToTechnology", 0);
        PlayerPrefs.SetInt("MarsEnergyHarnessed", 0);
        PlayerPrefs.SetInt("MarsNoOfStructures", 0);
        PlayerPrefs.SetInt("MarsEnergyUtilised", 0);
        PlayerPrefs.SetInt("MarsEnergyStructuresBuilt", 0);
        PlayerPrefs.SetInt("MarsFoodProduced", 0);
        PlayerPrefs.SetInt("MarsFoodUtilised", 0);
        PlayerPrefs.SetInt("MarsFoodStructuresBuilt", 0);
        PlayerPrefs.SetInt("MarsChemicalsExtracted", 0);
        PlayerPrefs.SetInt("MarsChemicalStructuresBuilt", 0);
        PlayerPrefs.SetInt("MarsCorrosionLevels", 0);
        PlayerPrefs.SetInt("MarsTotalUpgrades", 0);
        PlayerPrefs.SetInt("MarsTotalResearches", 0);

        PlayerPrefs.SetInt("UserFoodCapacity", 50000);
        PlayerPrefs.SetInt("UserChemicalCapacity", 50000);
        PlayerPrefs.SetInt("UserEnergyCapacity", 50000);
        PlayerPrefs.SetInt("UserCosmicCashCapacity", 50000);

        for (int i = 1; i < 14; i++)
        { 
            string deletekey = "Objective" + i + "Done";
            if(PlayerPrefs.HasKey(deletekey))
            {
                PlayerPrefs.DeleteKey(deletekey);
            }
        }

        PlayerPrefs.DeleteKey("ObjectivesDone");
        objHandler.ObjectivesDone = 0;
        PlayerPrefs.SetInt("ObjectivesDone", objHandler.ObjectivesDone);
        if (objHandler.ObjectivesDone == 0)
        {
            objHandler.ObjectiveText1.text = objHandler.Objectives[0];
            objHandler.ObjectiveText2.text = objHandler.Objectives[1];
        }
        else
        {
            if (objHandler.ObjectivesDone / 2 > 0)
            {
                objHandler.ObjectiveText1.text = objHandler.Objectives[objHandler.ObjectivesDone];
                objHandler.ObjectiveText2.text = objHandler.Objectives[objHandler.ObjectivesDone + 1];
            }
            else
            {
                objHandler.ObjectiveText1.text = objHandler.Objectives[objHandler.ObjectivesDone - 1];
                objHandler.ObjectiveText2.text = objHandler.Objectives[objHandler.ObjectivesDone];
            }
        }

        objTextHandler.ObjectiveTick1.sprite = objTextHandler.NoTickImage;
        objTextHandler.ObjectiveTick2.sprite = objTextHandler.NoTickImage;

        objTextHandler.objnumber1 = objHandler.ObjectivesDone + 1;
        objTextHandler.objnumber2 = objHandler.ObjectivesDone + 2;
        objTextHandler.obj1pref = "Objective" + objTextHandler.objnumber1 + "Done";
        objTextHandler.obj2pref = "Objective" + objTextHandler.objnumber2 + "Done";


        for (int i = 0; i < structurescreated.Count; i++)
        {
            Destroy(structurescreated[i]);
        }

        if(structurescreated.Count > 0)
        {
            structurescreated.Clear();
        }
    }
}
