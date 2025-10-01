using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetClick : MonoBehaviour 
{
	
	public GameObject MainCam;
	public GameObject SciFi_Mars;
	bool saturn = false;
	bool earth,uranus,sun,mercury,venus,jupiter,pluto,mars,neptune = false;
	GameObject Mercury,Venus,Earth,Mars,Jupiter,Saturn,Uranus,Neptune,Pluto;
	public bool mars_scifi = false;
	void Awake()
	{
		MainCam = GameObject.Find ("Main Camera");
		Mercury = GameObject.Find ("Mercury");
		Venus = GameObject.Find ("Venus");
		Earth = GameObject.Find ("Earth");
		Mars = GameObject.Find ("Mars");
		Jupiter = GameObject.Find ("Jupiter");
		Saturn = GameObject.Find ("Saturn");
		Uranus = GameObject.Find ("Uranus");
		Neptune = GameObject.Find ("Neptune");
		Pluto = GameObject.Find ("Pluto");
	}
	void Start () 
	{
		
		SciFi_Mars.gameObject.SetActive (false);
	}

	void ResetMars()
	{
		SciFi_Mars.SetActive (false);
		SciFi_Mars.transform.parent.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		SciFi_Mars.transform.GetChild (0).gameObject.GetComponent<RotateCarrier> ().enabled = false;
		SciFi_Mars.transform.GetChild (1).gameObject.GetComponent<RotateCarrier> ().enabled = false;
		SciFi_Mars.transform.GetChild (2).gameObject.GetComponent<RotateCoin> ().enabled = false;
		PlayerPrefs.DeleteKey ("Mars");
	}
	void ResetColliders()
	{
		Mercury.GetComponent<SphereCollider> ().enabled = true;
		Venus.GetComponent<SphereCollider> ().enabled = true;
		Earth.GetComponent<SphereCollider> ().enabled = true;
		Mars.GetComponent<SphereCollider> ().enabled = true;
		Jupiter.GetComponent<SphereCollider> ().enabled = true;
		Saturn.GetComponent<SphereCollider> ().enabled = true;
		Uranus.GetComponent<SphereCollider> ().enabled = true;
		Neptune.GetComponent<SphereCollider> ().enabled = true;
		Pluto.GetComponent<SphereCollider> ().enabled = true;
	}
	void OnMouseUp()
	{
		if (gameObject.name == "Saturn") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Saturn");
			saturn = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			ResetMars ();
		}
		if (gameObject.name == "Earth") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 4f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Earth");
			earth = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			ResetMars ();
		}
		if (gameObject.name == "Uranus") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Uranus");
			uranus = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			ResetMars ();
		}
		if (gameObject.name == "Sun") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Sun");
			sun = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			ResetMars ();
		}
		if (gameObject.name == "Mercury") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Mercury");
			mercury = true;
			ResetColliders ();
			ResetMars ();
		}
		if (gameObject.name == "Venus") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Venus");
			venus = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			ResetMars ();
		}
		if (gameObject.name == "Jupiter") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Jupiter");
			jupiter = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			ResetMars ();
		}
		if (gameObject.name == "Pluto") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Pluto");
			pluto = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			ResetMars ();
		}
		if (gameObject.name == "Neptune") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Neptune");
			neptune = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			ResetMars ();
		}
		if (gameObject.name == "Mars") 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance = 6f;
			MainCam.GetComponent<PlanetariumCamera> ().target = GameObject.Find("Mars");
			mars = true;
			ResetColliders ();
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			PlayerPrefs.SetInt ("Mars", 1);
		}
	}
	void Update() 
	{
		if (saturn) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.1f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 1) 
			{
				saturn = false;
			}
		}
		if (earth) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 0.5f) 
			{
				earth = false;
			}
		}
		if (uranus) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 0.8f) 
			{
				uranus = false;
			}
		}
		if (sun) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 1.5f) 
			{
				sun = false;
			}
		}
		if (mercury) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 0.4f) 
			{
				mercury = false;
			}
		}
		if (venus) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 0.5f) 
			{
				venus = false;
			}
		}
		if (jupiter) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 1f) 
			{
				jupiter = false;
			}
		}
		if (pluto) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 0.4f) 
			{
				pluto = false;
			}
		}
		if (neptune) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 0.75f) 
			{
				neptune = false;
			}
		}
		if (mars) 
		{
			MainCam.GetComponent<PlanetariumCamera> ().distance -= 0.2f;
			if (MainCam.GetComponent<PlanetariumCamera> ().distance <= 0.5f) 
			{
				StartCoroutine (FadeInScene ());
				mars = false;
				//Mars.GetComponent<Animator> ().enabled = true;
			}
		}
}


	IEnumerator FadeInScene()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("HexagonPlanet");
	}
}
