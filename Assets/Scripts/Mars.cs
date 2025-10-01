using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mars : MonoBehaviour 
{


	void Start () 
	{
		StartCoroutine (FadeOutScene ());
	}
	

	void Update ()
	{
		
	}
	IEnumerator FadeOutScene()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (-1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("SolarSystem");
	}
}
