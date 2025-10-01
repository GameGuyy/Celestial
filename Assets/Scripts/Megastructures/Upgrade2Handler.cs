using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade2Handler : MonoBehaviour
{
    public int u2foodused;
    public int u2chemicalused;
    public int u2cosmiccashused;
    public int u2energyused;
    public int u2technologyused;
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
		MegastructureData = gameObject.GetComponent<BaseMegastructure> ();
		timer = gameObject.GetComponent<ConstructionCountdown> ();
		buildercheck = GameObject.Find ("Main Camera").GetComponent<BuilderChecker> ();
        NotEnoughFood = GameObject.Find("LimitedContentTabFood");
        NotEnoughEnergy = GameObject.Find("LimitedContentTabEnergy");
        NotEnoughChemical = GameObject.Find("LimitedContentTabChemical");
        NotEnoughCosmicCash = GameObject.Find("LimitedContentTabCosmicCash");
        NotEnoughTechnology = GameObject.Find("LimitedContentTabTechnology");
    }

    public void OnConstructionStartUpgrade2()
    {
        int userEnergy = PlayerPrefs.GetInt("UserEnergy");
        if (userEnergy < u2energyused)
        {
            NotEnoughEnergy.GetComponent<Animator>().enabled = true;
            NotEnoughEnergy.GetComponent<Animator>().SetBool("Close", false);
        }
        else
        {
            int UserFood = PlayerPrefs.GetInt("UserFood");
            if (UserFood < u2foodused)
            {
                NotEnoughFood.GetComponent<Animator>().enabled = true;
                NotEnoughFood.GetComponent<Animator>().SetBool("Close", false);
            }
            else
            {
                int UserCosmicCash = PlayerPrefs.GetInt("UserCosmicCash");
                if (UserCosmicCash < u2cosmiccashused)
                {
                    NotEnoughCosmicCash.GetComponent<Animator>().enabled = true;
                    NotEnoughCosmicCash.GetComponent<Animator>().SetBool("Close", false);
                }
                else
                {
                    int UserChemical = PlayerPrefs.GetInt("UserChemical");
                    if (UserChemical < u2chemicalused)
                    {
                        NotEnoughChemical.GetComponent<Animator>().enabled = true;
                        NotEnoughChemical.GetComponent<Animator>().SetBool("Close", false);
                    }
                    else
                    {
                        int UserTechnology = PlayerPrefs.GetInt("UserTechnology");
                        if (UserTechnology < u2technologyused)
                        {
                            NotEnoughTechnology.GetComponent<Animator>().enabled = true;
                            NotEnoughTechnology.GetComponent<Animator>().SetBool("Close", false);
                        }
                        else
                        {
                            //StartTimer
							int chemical = PlayerPrefs.GetInt("UserChemical");
							chemical -= u2chemicalused;
							PlayerPrefs.SetInt("UserChemical", chemical);
							int food = PlayerPrefs.GetInt("UserFood");
							food -= u2foodused;
							PlayerPrefs.SetInt("UserFood", food);
							int cosmiccash = PlayerPrefs.GetInt("UserCosmicCash");
							cosmiccash -= u2cosmiccashused;
							PlayerPrefs.SetInt("UserCosmicCash", cosmiccash);
                            PlayerPrefs.SetInt(MegastructureData.structurelevelsave, 3);
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
                           // PlayerPrefs.SetInt(structurename, 1);
                        }
                    }
                }
            }
        }
    }
}
