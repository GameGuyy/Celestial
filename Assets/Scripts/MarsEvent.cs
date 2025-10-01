using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsEvent : MonoBehaviour 
{
	public GameObject MarsSciFiObj;
	void Start () 
	{
		
	}
	public void MarsSciFiEffect()
	{
		MarsSciFiObj.SetActive (true);
		GameObject.Find ("Mars").GetComponent<MeshRenderer> ().enabled = false;
		MarsSciFiObj.transform.GetChild (0).gameObject.GetComponent<RotateCarrier> ().enabled = true;
		MarsSciFiObj.transform.GetChild (1).gameObject.GetComponent<RotateCarrier> ().enabled = true;
		MarsSciFiObj.transform.GetChild (2).gameObject.GetComponent<RotateCoin> ().enabled = true;
		StartCoroutine (EffectOff ());
		gameObject.GetComponent<Animator> ().enabled = false;
	}
	IEnumerator EffectOff()
	{
		yield return new WaitForSeconds (4f);
		MarsSciFiObj.transform.GetChild (0).gameObject.GetComponent<RotateCarrier> ().enabled = false;
		MarsSciFiObj.transform.GetChild (1).gameObject.GetComponent<RotateCarrier> ().enabled = false;
		MarsSciFiObj.transform.GetChild (2).gameObject.GetComponent<RotateCoin> ().enabled = false;
	}

	void Update () 
	{
		
	}
}
