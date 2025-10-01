using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedContentTabSetter : MonoBehaviour 
{
	void SetAnimatorOff()
	{
		StartCoroutine (WaitAndSetOff());
	}

	IEnumerator WaitAndSetOff()
	{
		yield return new WaitForSeconds (3);
		gameObject.GetComponent<Animator> ().SetBool ("Close", true);
	}
}
