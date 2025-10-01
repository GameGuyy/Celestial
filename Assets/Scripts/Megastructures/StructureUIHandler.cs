using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureUIHandler : MonoBehaviour
{
    public GameObject StructureInfoPanel;
    public bool InfoOpen,UpgradeOpen;
    BaseMegastructure MegastructureData;
    Text Info, Info1, Info2, Info3, InfoName;
    Button Upgrade, Research, Repair;
    Text UpdateInfo, UpdateFood, UpdateChemical, UpdateCosmicCash;
    public GameObject UpdateResearchPanel;
	public GameObject MegastructurePanel;
	Button YesButton,NoButton;
	ConstructionCountdown timerScript;
    GameObject NotificationPanel;
    Text NotificationText1, NotificationText2;
    Button InfoBackButton;
    GameObject ObjectivesButton, ResetButton;
    SurfaceUI BoolChecker;
    Button StructureInfoButton;

    void Start()
    {
        BoolChecker = GameObject.Find("Main Camera").GetComponent<SurfaceUI>();
        timerScript = gameObject.GetComponent<ConstructionCountdown> ();
		MegastructurePanel = GameObject.Find ("MegaStructures");
        MegastructureData = gameObject.GetComponent<BaseMegastructure>();
        StructureInfoPanel = GameObject.Find("MegaStructureInfo");
        UpdateResearchPanel = GameObject.Find("UpgradeResearchPanel");
        NotificationPanel = GameObject.Find("NotificationPanel");
        ObjectivesButton = GameObject.Find("Objectives");
        ResetButton = GameObject.Find("ResetButton");

        NotificationText1 = NotificationPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        NotificationText2 = NotificationPanel.transform.GetChild(0).GetChild(1).GetComponent<Text>();

        UpdateInfo = UpdateResearchPanel.transform.GetChild(0).gameObject.GetComponent<Text>();
        UpdateFood = UpdateResearchPanel.transform.GetChild(1).gameObject.GetComponent<Text>();
        UpdateChemical = UpdateResearchPanel.transform.GetChild(2).gameObject.GetComponent<Text>();
        UpdateCosmicCash = UpdateResearchPanel.transform.GetChild(3).gameObject.GetComponent<Text>();

		YesButton = UpdateResearchPanel.transform.GetChild (4).gameObject.GetComponent<Button> ();
		NoButton = UpdateResearchPanel.transform.GetChild (5).gameObject.GetComponent<Button> ();

        // UpdateResearchPanel.SetActive(false);

        InfoName = StructureInfoPanel.transform.GetChild(1).gameObject.GetComponent<Text>();
        Info = StructureInfoPanel.transform.GetChild(2).gameObject.GetComponent<Text>();
        Info1 = StructureInfoPanel.transform.GetChild(3).gameObject.GetComponent<Text>();
        Info2 = StructureInfoPanel.transform.GetChild(4).gameObject.GetComponent<Text>();
        Info3 = StructureInfoPanel.transform.GetChild(5).gameObject.GetComponent<Text>();
        

        //InfoBackButton = StructureInfoPanel.transform.GetChild(5).GetComponent<Button>();
        //InfoBackButton.onClick.AddListener(() => OpenStructureInfoPanel());
        //InfoBackButton.gameObject.SetActive(false);

        Upgrade = StructureInfoPanel.transform.GetChild(6).GetComponent<Button>();
        

        Research = StructureInfoPanel.transform.GetChild(7).GetComponent<Button>();
       

        Repair = StructureInfoPanel.transform.GetChild(8).GetComponent<Button>();

        StructureInfoButton = StructureInfoPanel.transform.GetChild(9).GetComponent<Button>();
        StructureInfoButton.onClick.AddListener(() => StructureInfoClosed());


    }

    

    private void OnMouseUp()
    {
		if (timerScript.TimerOn == false) 
		{
			OpenStructureInfoPanel();
		}
    }

    public void OpenStructureInfoPanel()
    {
        Upgrade.onClick.RemoveAllListeners();
        Research.onClick.RemoveAllListeners();
        Repair.onClick.RemoveAllListeners();
        int level = PlayerPrefs.GetInt(MegastructureData.structurelevelsave);
        if (level <= 2)
        {
            Upgrade.gameObject.SetActive(true);
            Upgrade.onClick.AddListener(() => OnUpgradeClick());
        }
        else
        {
            Upgrade.gameObject.SetActive(false);
        }

        int research = PlayerPrefs.GetInt(MegastructureData.structureresearchlevel);
        if (research <= 2)
        {
            Research.gameObject.SetActive(true);
            Research.onClick.AddListener(() => OnResearchClick());
        }
        else
        {
            Research.gameObject.SetActive(false);
        }
        Repair.onClick.AddListener(() => OnRepairClick());

        InfoName.text = MegastructureData.structurename;
        Info.text = MegastructureData.structureInfo;

        if (MegastructureData.rate > 0)
        {
            Info1.text = "Production : " + MegastructureData.rate;
        }
        else if (MegastructureData.rate == 0)
        {
            Info1.text = "";
        }

        if(gameObject.tag != "Chemical" || gameObject.tag != "Food" || gameObject.tag != "CosmicCash" || gameObject.tag != "Energy")
        {
            if (MegastructureData.storage > 0)
            {
                Info2.text = "Capacity : " + MegastructureData.storage;
            }
            else if (MegastructureData.capacity > 0)
            {
                Info2.text = "Capacity : " + MegastructureData.capacity;
            }
            else if (MegastructureData.capacity == 0 && MegastructureData.storage == 0)
            {
                Info2.text = "";
            }
        }

        Info3.text = "Durability : " + MegastructureData.durability;

		if (GameObject.Find ("Main Camera").GetComponent<SurfaceUI> ().MegaBool == true) 
		{
			GameObject.Find ("Main Camera").GetComponent<SurfaceUI> ().StructureInfoOn = true;
			GameObject.Find ("Main Camera").GetComponent<SurfaceUI> ().MegaStructuresUp ();
		} 
		else 
		{
            ObjectivesButton.SetActive(false);
            ResetButton.SetActive(false);
            StructureInfoPanel.GetComponent<Animator>().enabled = true;
            StructureInfoPanel.GetComponent<Animator>().SetBool("Up", false);
            //InfoBackButton.gameObject.SetActive(true);
            MegastructurePanel.SetActive(false);
            InfoOpen = true;
            BoolChecker.ColliderOff = true;
		}
        
       
        
    }

    public void StructureInfoClosed()
    {
        ObjectivesButton.SetActive(true);
        ResetButton.SetActive(true);
        StructureInfoPanel.GetComponent<Animator>().enabled = true;
        StructureInfoPanel.GetComponent<Animator>().SetBool("Up", true);
        //InfoBackButton.gameObject.SetActive(false);
        MegastructurePanel.SetActive(true);
        BoolChecker.ColliderOff = false;
        InfoOpen = false;
    }

    public void OnUpgradeClick()
    {
        if(BoolChecker.BuilderBusy == false)
        {
            int level = PlayerPrefs.GetInt(MegastructureData.structurelevelsave);

            StructureInfoPanel.GetComponent<Animator>().enabled = true;
            StructureInfoPanel.GetComponent<Animator>().SetBool("Up", true);
            InfoOpen = false;

            UpdateResearchPanel.GetComponent<Animator>().enabled = true;
            UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", false);
            UpgradeOpen = true;

            BoolChecker.ColliderOff = true;

            if (level == 1)
            {
                UpdateInfo.text = gameObject.GetComponent<Upgrade1Handler>().structureInfo;
                if (gameObject.GetComponent<Upgrade1Handler>().u1foodused == 0)
                {
                    UpdateFood.text = "";
                }
                else
                {
                    UpdateFood.text = "Food: " + gameObject.GetComponent<Upgrade1Handler>().u1foodused;
                }

                UpdateChemical.text = "Chemical: " + gameObject.GetComponent<Upgrade1Handler>().u1chemicalused;
                UpdateCosmicCash.text = "CosmicCash: " + gameObject.GetComponent<Upgrade1Handler>().u1cosmiccashused;
            }
            else if (level == 2)
            {
                UpdateInfo.text = gameObject.GetComponent<Upgrade2Handler>().structureInfo;
                if (gameObject.GetComponent<Upgrade2Handler>().u2foodused == 0)
                {
                    UpdateFood.text = "";
                }
                else
                {
                    UpdateFood.text = "Food: " + gameObject.GetComponent<Upgrade2Handler>().u2foodused;
                }
                UpdateChemical.text = "Chemical: " + gameObject.GetComponent<Upgrade2Handler>().u2chemicalused;
                UpdateCosmicCash.text = "Cosmic Cash: " + gameObject.GetComponent<Upgrade2Handler>().u2cosmiccashused;
            }
            YesButton.onClick.RemoveAllListeners();
            NoButton.onClick.RemoveAllListeners();
            YesButton.onClick.AddListener(() => OnUpgradeYesClick());
            NoButton.onClick.AddListener(() => OnUpgradeNoClick());
        }
    }

    public void OnResearchClick()
    {
        if (BoolChecker.BuilderBusy == false)
        {
            StructureInfoPanel.GetComponent<Animator>().enabled = true;
            StructureInfoPanel.GetComponent<Animator>().SetBool("Up", true);
            InfoOpen = false;

            UpdateResearchPanel.GetComponent<Animator>().enabled = true;
            UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", false);
            UpgradeOpen = true;

            BoolChecker.ColliderOff = true;

            string prefs = MegastructureData.structureresearchlevel;
            if (PlayerPrefs.HasKey(prefs))
            {
                int researchlevel = PlayerPrefs.GetInt(prefs);
                if (researchlevel == 1)
                {
                    UpdateInfo.text = gameObject.GetComponent<Research1Handler>().structureInfo;
                    if (gameObject.GetComponent<Research1Handler>().r1foodused == 0)
                    {
                        UpdateFood.text = "";
                    }
                    else
                    {
                        UpdateFood.text = "Food: " + gameObject.GetComponent<Research1Handler>().r1foodused;
                    }

                    if (gameObject.GetComponent<Research1Handler>().r1chemicalused == 0)
                    {
                        UpdateChemical.text = "";
                    }
                    else
                    {
                        UpdateChemical.text = "Chemical: " + gameObject.GetComponent<Research1Handler>().r1chemicalused;
                    }
                    if (gameObject.GetComponent<Research1Handler>().r1cosmiccashused == 0)
                    {
                        UpdateCosmicCash.text = "";
                    }
                    else
                    {
                        UpdateCosmicCash.text = "CosmicCash: " + gameObject.GetComponent<Research1Handler>().r1cosmiccashused;
                    }
                }
            }
            else
            {
                UpdateInfo.text = gameObject.GetComponent<Research2Handler>().structureInfo;
                UpdateFood.text = "Food: " + gameObject.GetComponent<Research2Handler>().r2foodused;
                UpdateChemical.text = "Chemical: " + gameObject.GetComponent<Research2Handler>().r2chemicalused;
                UpdateCosmicCash.text = "Cosmic Cash: " + gameObject.GetComponent<Research2Handler>().r2cosmiccashused;
            }

            YesButton.onClick.RemoveAllListeners();
            NoButton.onClick.RemoveAllListeners();
            YesButton.onClick.AddListener(() => OnResearchYesClick());
            NoButton.onClick.AddListener(() => OnResearchNoClick());
        }
    }

	public void OnResearchYesClick()
	{
        string prefs = MegastructureData.structureresearchlevel;

        UpdateResearchPanel.GetComponent<Animator>().enabled = true;
        UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", true);
        UpgradeOpen = false;
        ObjectivesButton.SetActive(true);
        ResetButton.SetActive(true);
        BoolChecker.ColliderOff = false;

        MegastructurePanel.SetActive (true);
		if (PlayerPrefs.HasKey (prefs)) 
		{
			int researchlevel = PlayerPrefs.GetInt (prefs);
			if (researchlevel == 1) 
			{
				gameObject.GetComponent<Research2Handler> ().ConstructionStartResearch2 ();
			}
		} 
		else 
		{
			gameObject.GetComponent<Research1Handler> ().ConstructionStartResearch1 ();
		}
	}

	public void OnResearchNoClick()
	{

        BoolChecker.ColliderOff = false;
        StructureInfoPanel.GetComponent<Animator>().enabled = true;
		StructureInfoPanel.GetComponent<Animator>().SetBool("Up", false);
		InfoOpen = true;

		UpdateResearchPanel.GetComponent<Animator>().enabled = true;
		UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", true);
		UpgradeOpen = false;
    }
    
    public void OnRepairClick()
    {
        StructureInfoPanel.GetComponent<Animator>().enabled = true;
        StructureInfoPanel.GetComponent<Animator>().SetBool("Up", true);
        InfoOpen = false;

        UpdateResearchPanel.GetComponent<Animator>().enabled = true;
        UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", false);
        UpgradeOpen = true;
        BoolChecker.ColliderOff = true;

        UpdateInfo.text = "Do you want to repair?";
        UpdateFood.text = "";
        UpdateChemical.text = "";
        UpdateCosmicCash.text = "";

        YesButton.onClick.RemoveAllListeners();
        NoButton.onClick.RemoveAllListeners();
        YesButton.onClick.AddListener(() => OnRepairYesClick());
        NoButton.onClick.AddListener(() => OnRepairNoClick());
    }

    void OnRepairYesClick()
    {
        UpdateResearchPanel.GetComponent<Animator>().enabled = true;
        UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", true);
        UpgradeOpen = false;
        ObjectivesButton.SetActive(true);
        ResetButton.SetActive(true);
        BoolChecker.ColliderOff = false;

        MegastructurePanel.SetActive (true);

        MegastructureData.durability = MegastructureData.ogdurability;
        NotificationText1.text = "Your structure has been repaired!";
        NotificationText2.text = "";
        NotificationPanel.GetComponent<Animator>().enabled = true;
        NotificationPanel.GetComponent<Animator>().SetBool("Down", true);
    }

    void OnRepairNoClick()
    {
        BoolChecker.ColliderOff = false;
        StructureInfoPanel.GetComponent<Animator>().enabled = true;
		StructureInfoPanel.GetComponent<Animator>().SetBool("Up", false);
		InfoOpen = true;

		UpdateResearchPanel.GetComponent<Animator>().enabled = true;
		UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", true);
		UpgradeOpen = false;
    }

    void OnUpgradeYesClick()
    {
		int level = PlayerPrefs.GetInt(MegastructureData.structurelevelsave);

        UpdateResearchPanel.GetComponent<Animator>().enabled = true;
        UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", true);
        UpgradeOpen = false;
        ObjectivesButton.SetActive(true);
        ResetButton.SetActive(true);
        BoolChecker.ColliderOff = false;

        MegastructurePanel.SetActive (true);

		if (level == 1) 
		{
			gameObject.GetComponent<Upgrade1Handler> ().OnConstructionStartUpgrade1 ();
		} 
		else if (level == 2) 
		{
			gameObject.GetComponent<Upgrade2Handler> ().OnConstructionStartUpgrade2 ();
		}

    }

    void OnUpgradeNoClick()
    {
        BoolChecker.ColliderOff = true;
        StructureInfoPanel.GetComponent<Animator>().enabled = true;
		StructureInfoPanel.GetComponent<Animator>().SetBool("Up", false);
		InfoOpen = true;

		UpdateResearchPanel.GetComponent<Animator>().enabled = true;
		UpdateResearchPanel.GetComponent<Animator>().SetBool("Up", true);
		UpgradeOpen = false;
    }
}
