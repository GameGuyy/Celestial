using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarSystemPlanetUI : MonoBehaviour
{
    public List<Text> PlanetInfoTexts;
    public MarsData marsData;

    public Text marsFood, marsTechonology, marsChemical, marsEnergy, marsCosmicCash;
	void Start ()
    {
      //  PlanetInfoTexts[0].text = "Name : " + MarsData.PlanetName;
      //  PlanetInfoTexts[1].text = "Type : " + MarsData.Type;
      //  PlanetInfoTexts[2].text = "Rotational Period : " + marsData.rotationalperiod;
      //  PlanetInfoTexts[3].text = "Hostility : " + marsData.hostility;
      //  PlanetInfoTexts[4].text = "Habitability : " + marsData.habitability;
      //  PlanetInfoTexts[5].text = "Hazards : " + marsData.hazards;
    }

	void Update ()
    {
		
	}

    public void GlobalValuesSet()
    {
        marsChemical.text = "" + PlayerPrefs.GetInt("UserChemical");
        marsFood.text = "" + PlayerPrefs.GetInt("UserFood");
        marsTechonology.text = "" + PlayerPrefs.GetInt("UserTechnology");
        marsCosmicCash.text = "" + PlayerPrefs.GetInt("UserCosmicCash");
        marsEnergy.text = "" + PlayerPrefs.GetInt("UserEnergy");

        StartCoroutine(WaitAndReset());
    }

    IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(6);
        marsChemical.text = "" + PlayerPrefs.GetInt("MarsChemical");
        marsFood.text = "" + PlayerPrefs.GetInt("MarsFood");
        marsTechonology.text = "" + PlayerPrefs.GetInt("MarsTechnology");
        marsCosmicCash.text = "" + PlayerPrefs.GetInt("MarsCosmicCash");
        marsEnergy.text = "" + PlayerPrefs.GetInt("MarsEnergy");
    }
}
