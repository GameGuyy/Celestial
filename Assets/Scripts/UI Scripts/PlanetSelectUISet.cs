using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSelectUISet : MonoBehaviour
{
    public Text marsFood, marsTechonology, marsChemical, marsEnergy, marsCosmicCash;

    void Start ()
    {
        marsChemical.text = "" + PlayerPrefs.GetInt("MarsChemical");
        marsFood.text = "" + PlayerPrefs.GetInt("MarsFood");
        marsTechonology.text = "" + PlayerPrefs.GetInt("MarsTechnology");
        marsCosmicCash.text = "" + PlayerPrefs.GetInt("MarsCosmicCash");
        marsEnergy.text = "" + PlayerPrefs.GetInt("MarsEnergy");
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
