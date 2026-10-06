using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private float rotateSpeed = 100f;
    private float zoomSpeed = 10f;
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    Coroutine rotateRoutine;
    Coroutine zoomRoutine;

    public UI UI;
    //private LightController lightController;

    void Start()
    {
	    transform.position = new Vector3(0f, 2f, -2f);
	    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	    targetRotation = transform.rotation;
	    targetPosition = transform.position;
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
		    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
		    yield return null; // wait one frame
	    }

	    transform.rotation = targetRotation; // snap to exact final value
	    rotateRoutine = null;
    }

    public void zoomOutCamera()
    {
	    UI.rotateButtons();
	    targetPosition = new Vector3(0f, 2f, -2f);
	    StartZoom();
    }
    public void zoomCameraIn(/*thing zooming in on?*/)
    {
	    if (transform.position != new Vector3(0f, 2f, -2f))
	    {
		    return;
	    }
	    UI.zoomButton();
	    if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, 0f, 0)) == 0f)
	    {
		    targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z+5f);
	    }
	    else if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, 90f, 0)) == 0f)
	    {
		    targetPosition = new Vector3(transform.position.x+5f, transform.position.y, transform.position.z);
	    }
	    else if(Quaternion.Angle(transform.rotation,  Quaternion.Euler(0,180f,0)) == 0f) // check camera orientation
	    {
		    targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z-5f);
	    }
	    else
	    {
		    targetPosition = new Vector3(transform.position.x-5f, transform.position.y, transform.position.z);
	    }
	    StartZoom();
    }
    void StartZoom()
    {
	    // Stop any rotation already in progress so two coroutines don't fight
	    if (zoomRoutine != null)
		    StopCoroutine(zoomRoutine);

	    zoomRoutine = StartCoroutine(zoomCamera());
    }

    IEnumerator zoomCamera()
    {
	    // Keep rotating until we've reached the target
	    while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
	    {
		    transform.position = Vector3.MoveTowards(transform.position, targetPosition, zoomSpeed * Time.deltaTime);
		    yield return null; // wait one frame
	    }

	    transform.position = targetPosition; // snap to exact final value
	    zoomRoutine = null;
    }
}
