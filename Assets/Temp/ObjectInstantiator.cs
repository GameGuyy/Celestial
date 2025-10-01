using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectInstantiator : MonoBehaviour
{
	public GameObject obj;
	public Transform plane;
	public int range;
	public Transform spawn;
	public bool is_created,mouse_pressed;
	public GameObject created_object;
	SurfaceUI surfaceUI;
	BuilderChecker buildercheck;
    bool PointerUp;
    GameObject ObjectivesButton, ResetButton;

	void Start () 
	{
        ObjectivesButton = GameObject.Find("Objectives");
        ResetButton = GameObject.Find("ResetButton");
		is_created = false;
		mouse_pressed = false;
		surfaceUI = GameObject.Find ("Main Camera").GetComponent<SurfaceUI> ();
		buildercheck = GameObject.Find ("Main Camera").GetComponent<BuilderChecker> ();
	}
	

	void Update () 
	{
        CheckMouseClick();
        MouseDrag();
	}

	void CheckMouseClick()
	{
		if(!is_created) 
		{


		} 
		else 
		{

			if(Input.GetMouseButtonDown (0)) 
			{

				mouse_pressed = true;
			} 
			else if(Input.GetMouseButtonUp (0)) 
			{

				MouseUp();
			}
		}
	}

	void MouseDrag() 
	{
        if(surfaceUI.BuilderBusy == false)
        {
            if (HasMouseMoved() && is_created)
            {
                if (mouse_pressed)
                {
                    created_object.SetActive(true);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, range) && hit.transform.tag == "plane")
                    {
                        PointerUp = true;
                        Vector3 pos = new Vector3(hit.point.x, created_object.transform.position.y, hit.point.z);
                        created_object.transform.position = pos;
                        if (surfaceUI.MegaBool == true)
                        {
                            surfaceUI.ColliderOff = false;
                            ObjectivesButton.SetActive(true);
                            ResetButton.SetActive(true);
                            surfaceUI.MegaStuctures.GetComponent<Animator>().enabled = true;
                            surfaceUI.MegaStuctures.GetComponent<Animator>().SetBool("Up", true);
                            surfaceUI.MegaBool = false;
                        }

                    }

                }
                //Debug.Log(curPosition);
            }
        }
		//else if(Input.GetButtonDown ("Fire1") && !is_created){

		//	Instantiate(object, spawn.transform.position, Quaternion.identity);
		//	is_created= true;
		//}
	}
	void MouseUp()
	{
		if (mouse_pressed) 
		{
            //is_up = false;
            if(PointerUp)
            {
                created_object.GetComponent<BaseMegastructure>().OnConstructionStart();
            }
            is_created = false;
			mouse_pressed = false;
		}
	}

	public void onClick() 
	{
		created_object = Instantiate(obj, spawn.transform.position, Quaternion.identity) as GameObject;
		created_object.gameObject.SetActive (false);
		//Destroy(createdobject,1);
		is_created= true;

		BaseMegastructure structdata = created_object.GetComponent<BaseMegastructure> ();
		surfaceUI.structureinfo.text = structdata.structureInfo;
		surfaceUI.chemicalrequired.text = "" + structdata.chemicalused;
		surfaceUI.cosmiccashrequired.text = "" + structdata.cosmiccashused;
		if (structdata.foodused == 0) 
		{
			surfaceUI.foodrequired.text = "";
		} 
		else 
		{
			surfaceUI.foodrequired.text = "" + structdata.foodused;
		}
		surfaceUI.energychecked.text = "" + structdata.energyused;
		surfaceUI.technologychecked.text = "" + structdata.technologyused;
	}
	public void Buttonclick ()
	{
		PointerUp = false;
		Destroy (created_object);
	}

	bool HasMouseMoved()
	{
		return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
	}
}
