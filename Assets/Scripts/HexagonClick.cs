using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HexagonClick : MonoBehaviour 
{
	public CameraMoveToHexagon obj;
	public Material OnClickGlow;
	public Material Default;
	void Start () 
	{
		obj = GameObject.Find ("Main Camera").GetComponent<CameraMoveToHexagon> ();
	}


	void OnMouseUp()
	{
		obj.move = true;
		StartCoroutine (FadeIn ());
		GetComponent<Renderer> ().material = Default;
	}

	void OnMouseDown()
	{
		GetComponent<Renderer> ().material = OnClickGlow;
	}

	IEnumerator FadeIn()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("MarsSurface_Test");
	}
}
