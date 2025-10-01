using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1Handler : MonoBehaviour
{
    public int u1foodused;
    public int u1chemicalused;
    public int u1cosmiccashused;
    public int u1energyused;
    public int u1technologyused;
    public float timetaken;
    public string structureInfo;
	BaseMegastructure MegastructureData;
	ConstructionCountdown timer;
	public int durability;
	public int production;
	BuilderChecker buildercheck;
    public GameObject NotEnoughFood, NotEnoughEnergy, NotEnoughChemical, NotEnoughCosmicCash, NotEnoughTechnology;

    void Start()
	{
		buildercheck = GameObject.Find ("Main Camera").GetComponent<BuilderChecker> ();
		MegastructureData = gameObject.GetComponent<BaseMegastructure> ();
		timer = gameObject.GetComponent<ConstructionCountdown> ();
        NotEnoughFood = GameObject.Find("LimitedContentTabFood");
        NotEnoughEnergy = GameObject.Find("LimitedContentTabEnergy");
        NotEnoughChemical = GameObject.Find("LimitedContentTabChemical");
        NotEnoughCosmicCash = GameObject.Find("LimitedContentTabCosmicCash");
        NotEnoughTechnology = GameObject.Find("LimitedContentTabTechnology");
    }


    public void OnConstructionStartUpgrade1()
    {
        int userEnergy = PlayerPrefs.GetInt("UserEnergy");
        if (userEnergy < u1energyused)
        {
            NotEnoughEnergy.GetComponent<Animator>().enabled = true;
            NotEnoughEnergy.GetComponent<Animator>().SetBool("Close", false);
        }
        else
        {
            int UserFood = PlayerPrefs.GetInt("UserFood");
            if (UserFood < u1foodused)
            {
                NotEnoughFood.GetComponent<Animator>().enabled = true;
                NotEnoughFood.GetComponent<Animator>().SetBool("Close", false);
            }
            else
            {
                int UserCosmicCash = PlayerPrefs.GetInt("UserCosmicCash");
                if (UserCosmicCash < u1cosmiccashused)
                {
                    NotEnoughCosmicCash.GetComponent<Animator>().enabled = true;
                    NotEnoughCosmicCash.GetComponent<Animator>().SetBool("Close", false);
                }
                else
                {
                    int UserChemical = PlayerPrefs.GetInt("UserChemical");
                    if (UserChemical < u1chemicalused)
                    {
                        NotEnoughChemical.GetComponent<Animator>().enabled = true;
                        NotEnoughChemical.GetComponent<Animator>().SetBool("Close", false);
                    }
                    else
                    {
                        int UserTechnology = PlayerPrefs.GetInt("UserTechnology");
                        if (UserTechnology < u1technologyused)
                        {
                            NotEnoughTechnology.GetComponent<Animator>().enabled = true;
                            NotEnoughTechnology.GetComponent<Animator>().SetBool("Close", false);
                        }
                        else
                        {
                            //StartTimer
							int chemical = PlayerPrefs.GetInt("UserChemical");
							chemical -= u1chemicalused;
							PlayerPrefs.SetInt("UserChemical", chemical);
							int food = PlayerPrefs.GetInt("UserFood");
							food -= u1foodused;
							PlayerPrefs.SetInt("UserFood", food);
							int cosmiccash = PlayerPrefs.GetInt("UserCosmicCash");
							cosmiccash -= u1cosmiccashused;
							PlayerPrefs.SetInt("UserCosmicCash", cosmiccash);
                            PlayerPrefs.SetInt(MegastructureData.structurelevelsave, 2);
                            //if (buildercheck.BuilderBusy == false) 
                            //{
                            //	buildercheck.BuilderBusy = true;
                            //}
                            if (PlayerPrefs.HasKey("MarsTotalUpgrades"))
                            {
                                int number = PlayerPrefs.GetInt("MarsTotalUpgrades");
                                number++;
                                PlayerPrefs.SetInt("MarsTotalUpgrades", number);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("MarsTotalUpgrades", 1);
                            }
                            if (durability > 0) 
							{
								MegastructureData.durability += ((durability * MegastructureData.durability) / 100);
							}
								

							if (production > 0) 
							{
							}
							timer.startCollecting = false;
                            gameObject.GetComponent<ConstructionCountdown>().UpdateS = true;
                            timer.timer = timetaken;
							timer.TimerOn = true;
                           // PlayerPrefs.SetInt(structurename, 2);
                        }
                    }
                }
            }
        }
    }
}
