using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMoveToHexagon : MonoBehaviour 
{

	public Transform target;
	public float speed;
	public bool move = false;

	void Start () 
	{

	}

	void Update () 
	{
		if (move) 
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, target.position, step);
		}
	}

	public void GoBackToPlanet()
	{
		StartCoroutine (FadeIn ());
	}
	public void GoBackToSolarSystem()
	{
		StartCoroutine (FadeInSolar ());
	}


	IEnumerator FadeIn()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("HexagonPlanet");
	}
	IEnumerator FadeInSolar()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("SolarSystem");
	}
}
