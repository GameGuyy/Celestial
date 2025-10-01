using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research2Handler : MonoBehaviour 
{
	public int r2foodused;
	public int r2chemicalused;
	public int r2cosmiccashused;
	public int r2energyused;
	public int r2technologyused;
	public float timetaken;
	public string structureInfo;
	BaseMegastructure MegastructureData;
	ConstructionCountdown timer;
	public int durability;
	public int production;
	BuilderChecker buildercheck;
    public GameObject NotEnoughFood, NotEnoughEnergy, NotEnoughChemical, NotEnoughCosmicCash, NotEnoughTechnology;

    void Start () 
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

	public void ConstructionStartResearch2()
	{
		int userEnergy = PlayerPrefs.GetInt("UserEnergy");
		if (userEnergy < r2energyused)
		{
            NotEnoughEnergy.GetComponent<Animator>().enabled = true;
            NotEnoughEnergy.GetComponent<Animator>().SetBool("Close", false);
        }
		else
		{
			int UserFood = PlayerPrefs.GetInt("UserFood");
			if (UserFood < r2foodused)
			{
                NotEnoughFood.GetComponent<Animator>().enabled = true;
                NotEnoughFood.GetComponent<Animator>().SetBool("Close", false);
            }
			else
			{
				int UserCosmicCash = PlayerPrefs.GetInt("UserCosmicCash");
				if (UserCosmicCash < r2cosmiccashused)
				{
                    NotEnoughCosmicCash.GetComponent<Animator>().enabled = true;
                    NotEnoughCosmicCash.GetComponent<Animator>().SetBool("Close", false);
                }
				else
				{
					int UserChemical = PlayerPrefs.GetInt("UserChemical");
					if (UserChemical < r2chemicalused)
					{
                        NotEnoughChemical.GetComponent<Animator>().enabled = true;
                        NotEnoughChemical.GetComponent<Animator>().SetBool("Close", false);
                    }
					else
					{
						int UserTechnology = PlayerPrefs.GetInt("UserTechnology");
						if (UserTechnology < r2technologyused)
						{
                            NotEnoughTechnology.GetComponent<Animator>().enabled = true;
                            NotEnoughTechnology.GetComponent<Animator>().SetBool("Close", false);
                        }
						else
						{
							//StartTimer
							int chemical = PlayerPrefs.GetInt("UserChemical");
							chemical -= r2chemicalused;
							PlayerPrefs.SetInt("UserChemical", chemical);
							int food = PlayerPrefs.GetInt("UserFood");
							food -= r2foodused;
							PlayerPrefs.SetInt("UserFood", food);
							int cosmiccash = PlayerPrefs.GetInt("UserCosmicCash");
							cosmiccash -= r2cosmiccashused;
							PlayerPrefs.SetInt("UserCosmicCash", cosmiccash);
                            PlayerPrefs.SetInt(MegastructureData.structureresearchlevel, 3);
                            if (buildercheck.BuilderBusy == false) 
							{
								buildercheck.BuilderBusy = true;
							}
							if (durability > 0) 
							{
								MegastructureData.durability += ((durability * MegastructureData.durability) / 100);
							}

                            if (PlayerPrefs.HasKey("MarsTotalResearches"))
                            {
                                int number = PlayerPrefs.GetInt("MarsTotalResearches");
                                number++;
                                PlayerPrefs.SetInt("MarsTotalResearches", number);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("MarsTotalResearches", 1);
                            }

                            if (production > 0) 
							{
							}
							timer.startCollecting = false;
                            gameObject.GetComponent<ConstructionCountdown>().Research = true;
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
