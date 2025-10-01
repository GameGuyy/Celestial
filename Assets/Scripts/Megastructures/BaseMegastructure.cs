using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMegastructure : MonoBehaviour
{
    public string structurename;
    public int energyused;
    public int foodused;
    public int cosmiccashused;
    public int technologyused;
    public int chemicalused;
    public float timetaken;
    public string structureInfo;
    public int structureLevel;
    public int rate;
    public int capacity;
    public int techonologyrate;
    public int storage;
    public int ogcapacity;
    public int ogdurability;
	public int durability;
	BuilderChecker buildercheck;
	public GameObject NotEnoughFood, NotEnoughEnergy, NotEnoughChemical,NotEnoughCosmicCash,NotEnoughTechnology;
    public string structurelevelsave,structuresave,structureresearchlevel,structuredurability;
    public int structurenumber;
    CreateStructures AddToList;


    void Awake()
	{
		buildercheck = GameObject.Find ("Main Camera").GetComponent<BuilderChecker> ();
        AddToList = GameObject.Find("Canvas").GetComponent<CreateStructures>();
	}


    private void Start()
    {
		NotEnoughFood = GameObject.Find ("LimitedContentTabFood");
		NotEnoughEnergy = GameObject.Find ("LimitedContentTabEnergy");
		NotEnoughChemical = GameObject.Find ("LimitedContentTabChemical");
		NotEnoughCosmicCash = GameObject.Find ("LimitedContentTabCosmicCash");
        NotEnoughTechnology = GameObject.Find("LimitedContentTabTechnology");

        if (PlayerPrefs.HasKey(structurename))
        {
            structurenumber = PlayerPrefs.GetInt(structurename);
            structurenumber += 1;
            structuresave = structurename + structurenumber;
            structurelevelsave = structurename + structurenumber + "Level";
            structureresearchlevel = structurename + structurenumber + "Research";
        }
        else
        {
            structurenumber = 1;
            structuresave = structurename + structurenumber;
            structurelevelsave = structurename + structurenumber + "Level";
            structureresearchlevel = structurename + structurenumber + "Research";
        }

        structuredurability = structuresave + "Durability";

        if (PlayerPrefs.HasKey (structuredurability)) 
		{
			
		}
		else 
		{
			PlayerPrefs.SetInt (structuredurability, durability);
		}
        if(structurename == "Business Center")
        {
            rate = gameObject.GetComponent<CosmicCashCollector>().cosmiccashrate;
            capacity = gameObject.GetComponent<CosmicCashCollector>().capacity;
        }
        else if(structurename == "Drillers" || structurename == "Air Extractors")
        {
            rate = gameObject.GetComponent<ChemicalCollector>().chemicalrate;
            capacity = gameObject.GetComponent<ChemicalCollector>().capacity;
        }
        else if(structurename == "Greenhouse")
        {
            rate = gameObject.GetComponent<FoodCollector>().foodrate;
            capacity = gameObject.GetComponent<FoodCollector>().capacity;
        }
        else if(structurename == "Solar Voltaics" || structurename == "Hydro Power Plants" || structurename == "Wind Plant" || structurename == "Nuclear Power Plants")
        {
            rate = gameObject.GetComponent<EnergyCollector>().energyrate;
            capacity = gameObject.GetComponent<EnergyCollector>().capacity;
        }
        techonologyrate = gameObject.GetComponent<TechnologyCollector>().technologyrate;
    }

    public void OnConstructionStart()
    {
        int userEnergy = PlayerPrefs.GetInt("UserEnergy");
        if(userEnergy < energyused)
        {
			NotEnoughEnergy.GetComponent<Animator> ().enabled = true;
			NotEnoughEnergy.GetComponent<Animator> ().SetBool ("Close", false);
			Destroy (gameObject);
        }
        else
        {
            int UserFood = PlayerPrefs.GetInt("UserFood");
            if(UserFood < foodused)
            {
				NotEnoughFood.GetComponent<Animator> ().enabled = true;
				NotEnoughFood.GetComponent<Animator> ().SetBool ("Close", false);
				Destroy (gameObject);
            }
            else
            {
                int UserCosmicCash = PlayerPrefs.GetInt("UserCosmicCash");
                if (UserCosmicCash < cosmiccashused)
                {
					NotEnoughCosmicCash.GetComponent<Animator> ().enabled = true;
					NotEnoughCosmicCash.GetComponent<Animator> ().SetBool ("Close", false);
					Destroy (gameObject);
                }
                else
                {
                    int UserChemical = PlayerPrefs.GetInt("UserChemical");
                    if(UserChemical < chemicalused)
                    {
						NotEnoughChemical.GetComponent<Animator> ().enabled = true;
						NotEnoughChemical.GetComponent<Animator> ().SetBool ("Close", false);
						Destroy (gameObject);
                    }
                    else
                    {
                        int UserTechnology = PlayerPrefs.GetInt("UserTechnology");
                        if(UserTechnology < technologyused)
                        {
							NotEnoughTechnology.GetComponent<Animator> ().enabled = true;
							NotEnoughTechnology.GetComponent<Animator> ().SetBool ("Close", false);
							Destroy (gameObject);
                        }
                        else
                        {
                            //StartTimer
                            int chemical = PlayerPrefs.GetInt("UserChemical");
                            chemical -= chemicalused;
                            PlayerPrefs.SetInt("UserChemical", chemical);
                            int food = PlayerPrefs.GetInt("UserFood");
                            food -= foodused;
                            PlayerPrefs.SetInt("UserFood", food);
                            int cosmiccash = PlayerPrefs.GetInt("UserCosmicCash");
							cosmiccash -= cosmiccashused;
                            PlayerPrefs.SetInt("UserCosmicCash", cosmiccash);
                            if (PlayerPrefs.HasKey(structurename))
                            {
                                PlayerPrefs.SetInt(structurename, structurenumber);
                                PlayerPrefs.SetInt(structuresave, 1);
                                PlayerPrefs.SetInt(structurelevelsave, 1);
                                PlayerPrefs.SetFloat(structureresearchlevel, 1);
                                Transform objPosition = gameObject.transform;
                                string posx = structuresave + "x";
                                Debug.Log(posx);
                                string posy = structuresave + "y";
                                Debug.Log(posy);
                                string posz = structuresave + "z";
                                Debug.Log(posz);
                                PlayerPrefs.SetFloat(posx, objPosition.position.x);
                                PlayerPrefs.SetFloat(posy, objPosition.position.y);
                                PlayerPrefs.SetFloat(posz, objPosition.position.z);
                                if(gameObject.tag == "Chemical")
                                {
                                    if (PlayerPrefs.HasKey("MarsChemicalStructuresBuilt"))
                                    {
                                        int number = PlayerPrefs.GetInt("MarsChemicalStructuresBuilt");
                                        number += 1;
                                        PlayerPrefs.SetInt("MarsChemicalStructuresBuilt", number);
                                    }
                                    else
                                    {
                                        PlayerPrefs.SetInt("MarsChemicalStructuresBuilt", 1);
                                    }
                                }

                                if (gameObject.tag == "Energy")
                                {
                                    if (PlayerPrefs.HasKey("MarsEnergyStructuresBuilt"))
                                    {
                                        int number = PlayerPrefs.GetInt("MarsEnergyStructuresBuilt");
                                        number += 1;
                                        PlayerPrefs.SetInt("MarsEnergyStructuresBuilt", number);
                                    }
                                    else
                                    {
                                        PlayerPrefs.SetInt("MarsEnergyStructuresBuilt", 1);
                                    }
                                }

                                if (gameObject.tag == "Food")
                                {
                                    if (PlayerPrefs.HasKey("MarsFoodStructuresBuilt"))
                                    {
                                        int number = PlayerPrefs.GetInt("MarsFoodStructuresBuilt");
                                        number += 1;
                                        PlayerPrefs.SetInt("MarsFoodStructuresBuilt", number);
                                    }
                                    else
                                    {
                                        PlayerPrefs.SetInt("MarsFoodStructuresBuilt", 1);
                                    }
                                }
                            }
                            else
                            {
                                PlayerPrefs.SetInt(structurename, structurenumber);
                                PlayerPrefs.SetInt(structuresave, 1);
                                PlayerPrefs.SetInt(structurelevelsave, 1);
                                PlayerPrefs.SetFloat(structureresearchlevel, 1);
                                Transform objPosition = gameObject.transform;
                                string posx = structuresave + "x";
                                string posy = structuresave + "y";
                                string posz = structuresave + "z";
                                PlayerPrefs.SetFloat(posx, objPosition.position.x);
                                PlayerPrefs.SetFloat(posy, objPosition.position.y);
                                PlayerPrefs.SetFloat(posz, objPosition.position.z);
                            }

                            if(PlayerPrefs.HasKey("MarsNoOfStructures"))
                            {
                                int noofstructures = PlayerPrefs.GetInt("MarsNoOfStructures");
                                noofstructures += 1;
                                PlayerPrefs.SetInt("MarsNoOfStructures", noofstructures);
                            }
                            else
                            {
                                PlayerPrefs.SetInt("MarsNoOfStructures", 1);
                            }

                            //PlayerPrefs.SetInt(structurename, 1);
                            //if (buildercheck.BuilderBusy == false) 
                            //{
                            //	buildercheck.BuilderBusy = true;
                            //}
                            AddToList.structurescreated.Add(gameObject);
                            gameObject.GetComponent<ConstructionCountdown>().Construction = true;
                            gameObject.GetComponent<ConstructionCountdown>().timer = timetaken;
                            gameObject.GetComponent<ConstructionCountdown>().TimerOn = true;
                        }
                    }
                }
            }
        }
    }
}
