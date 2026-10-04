using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private float speed = 100f;
    private Quaternion targetRotation;
    Coroutine rotateRoutine;
    //private LightController lightController;

    void Start()
    {
	    transform.position = new Vector3(0f, 1f, 0f);
	    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	    targetRotation = transform.rotation;
	    //lightController = FindObjectOfType<LightController>();
    }

    public void rotateCameraLeft()
    {
	    targetRotation *= Quaternion.Euler(0, -90f, 0);
	    StartRotation();
	    //lightController.rotateLightLeft();
    }

    public void rotateCameraRight()
    {
	    targetRotation *= Quaternion.Euler(0, 90f, 0);
	    StartRotation();
	    //lightController.rotateLightRight();
    }

    void StartRotation()
    {
	    // Stop any rotation already in progress so two coroutines don't fight
	    if (rotateRoutine != null)
		    StopCoroutine(rotateRoutine);

	    rotateRoutine = StartCoroutine(rotateCamera());
    }

    IEnumerator rotateCamera()
    {
	    // Keep rotating until we've reached the target
	    while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
	    {
		    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
		    yield return null; // wait one frame
	    }

	    transform.rotation = targetRotation; // snap to exact final value
	    rotateRoutine = null;
    }
    
    public void zoomCamera(/*thing zooming in on?*/)
    {
       
    }
}
