using UnityEngine;
using System.Collections;

/// <summary>
/// Attaches a trailing effect when the object is being dragged.
/// </summary>
public class DragTrail : MonoBehaviour 
{
	public LineRenderer lineRendererPrefab;
	public GameObject MegaStructure;
	public GameObject MegaStructurePrefab;
	LineRenderer lineRenderer;
	Vector3 StartPos;
	void Start()
	{
		lineRenderer = Instantiate( lineRendererPrefab, transform.position, transform.rotation ) as LineRenderer;
		lineRenderer.transform.parent = this.transform;
		lineRenderer.enabled = false;
	}
        
	void Update()
	{
		if( lineRenderer.enabled )
		{
			// update position of the line's end point
			lineRenderer.SetPosition( 1, transform.position );
		}
	}

    #region FingerGestures Events

    void OnDrag( DragGesture gesture )
    {
        if( gesture.Phase == ContinuousGesturePhase.Started )
        {
            // initialize the line renderer
			StartPos = transform.position;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition( 0, transform.position );
            lineRenderer.SetPosition( 1, transform.position );

            // keep end point width in sync with object's current scale
            lineRenderer.SetWidth( 0.01f, transform.localScale.x );
			//gameObject.transform.parent = null;
			MegaStructure = Instantiate (MegaStructurePrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
			MegaStructure.transform.parent = gameObject.transform;

		}
        else if( gesture.Phase == ContinuousGesturePhase.Ended )
        {
			MegaStructure.transform.parent = GameObject.Find("MarsLand").transform;
			MegaStructure.transform.rotation = Quaternion.identity;
		//	MegaStructure.transform.position = GameObject.Find ("Reference").transform.position;
            lineRenderer.enabled = false;
			transform.position = StartPos;
        }
    }

    #endregion
}
