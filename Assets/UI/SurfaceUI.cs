using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurfaceUI : MonoBehaviour 
{

	public GameObject ObjectivePanel;
	public GameObject MegaStuctures;
	public bool MegaBool = false;
	bool ObjectiveBool = false;
	public Text structureinfo,chemicalrequired,cosmiccashrequired,foodrequired,technologychecked,energychecked;
	public bool StructureInfoOn;
    public BaseMegastructure CommandCentrePref;
    public GameObject ObjectivesButton;
    public GameObject ResetButton;
    public bool ColliderOff;
    public bool BuilderBusy;
    public GameObject EventSystemObj;

	void Start () 
	{
		
	}
	

	void Update () 
	{
	}

	public void ObjectiveDown()
	{
		if (ObjectiveBool == true) 
		{
			ObjectivePanel.GetComponent<Animator> ().enabled = true;
			ObjectivePanel.GetComponent<Animator> ().SetBool ("Down", true);
            ColliderOff = false;
            ObjectiveBool = false;
		} 
		else if (ObjectiveBool == false) 
		{
			ObjectivePanel.GetComponent<Animator> ().enabled = true;
			ObjectivePanel.GetComponent<Animator> ().SetBool ("Down", false);
            ColliderOff = true;
            ObjectiveBool = true;
		}

        ObjectivesButton.GetComponent<Animator>().enabled = false;
        ObjectivesButton.GetComponent<Image>().material = null;

    }

	public void MegaStructuresUp()
	{
		if (MegaBool == true) 
		{
            ObjectivesButton.SetActive(true);
            ResetButton.SetActive(true);
			MegaStuctures.GetComponent<Animator> ().enabled = true;
			MegaStuctures.GetComponent<Animator> ().SetBool ("Up", true);
            ColliderOff = false;
            MegaBool = false;
		} 
		else if (MegaBool == false) 
		{
            structureinfo.text = CommandCentrePref.structureInfo;
            chemicalrequired.text = "" + CommandCentrePref.chemicalused;
            cosmiccashrequired.text = "" + CommandCentrePref.cosmiccashused;
			technologychecked.text = "" + CommandCentrePref.technologyused;
			energychecked.text = "" + CommandCentrePref.energyused;
            ObjectivesButton.SetActive(false);
            ResetButton.SetActive(false);
            ColliderOff = true;
            MegaStuctures.GetComponent<Animator> ().enabled = true;
			MegaStuctures.GetComponent<Animator> ().SetBool ("Up", false);
            MegaBool = true;
		}

	}


}
