using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	// STATE MACHINE????
	
    private float rotateSpeed = 100f;
    private float zoomSpeed = 10f;
    private Quaternion targetRotation;
    private Vector3 startingPosition = new Vector3(0f, 2f, -2f);
    private Vector3 targetPosition;
    
    public static Quaternion northRoom = Quaternion.Euler(0f, 0f, 0f);
    private Vector3 northRoomZoom = new Vector3(0f, 2f, 3f);
    public static Quaternion eastRoom = Quaternion.Euler(0f, 90f, 0f);
    private Vector3 eastRoomZoom = new Vector3(5f, 2f, -2f);
    public static Quaternion southRoom = Quaternion.Euler(0f, 180f, 0f);
    private Vector3 southRoomZoom = new Vector3(0f, 2f, -7f);
    public static Quaternion westRoom = Quaternion.Euler(0f, 270f, 0f);
    private Vector3 westRoomZoom = new Vector3(-5f, 2f, -2f);
    
    Quaternion[] rooms = new Quaternion[]{northRoom, eastRoom, southRoom, westRoom};
    int currentRoom;
    
    
    Coroutine rotateRoutine;
    Coroutine zoomRoutine;
    public UI UI;

    void Start()
    {
	    transform.position = startingPosition;
	    transform.rotation = northRoom;
	    currentRoom = 0;
	    targetRotation = transform.rotation;
	    targetPosition = transform.position;
    }

    public Quaternion getCurrentRoom()
    {
	    return rooms[currentRoom];
    }

    public Vector3 getCurrentPosition()
    {
	    return this.transform.position;
    }

    public void rotateCameraLeft()
    {
	    //targetRotation *= Quaternion.Euler(0, -90f, 0);
	    if (currentRoom == 0)
	    {
		    currentRoom = 3;
	    }
	    else
	    {
		    currentRoom--;
	    }
	    targetRotation = rooms[currentRoom];
	    StartRotation();
    }

    public void rotateCameraRight()
    {
	    //targetRotation *= Quaternion.Euler(0, 90f, 0);
	    if (currentRoom == 3)
	    {
		    currentRoom = 0;
	    }
	    else
	    {
		    currentRoom++;
	    }
	    targetRotation = rooms[currentRoom];
	    StartRotation();
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
	    targetRotation = rooms[currentRoom];
	    StartZoom();
	    StartRotation();
    }
    public void zoomCameraIn()
    {
	    if (transform.position != new Vector3(0f, 2f, -2f))
	    {
		    return;
	    }
	    UI.zoomButton();
	    if (Quaternion.Angle(transform.rotation, northRoom) == 0f)
	    {
		    targetPosition = northRoomZoom;
	    }
	    else if (Quaternion.Angle(transform.rotation, eastRoom) == 0f)
	    {
		    targetPosition = eastRoomZoom;
	    }
	    else if(Quaternion.Angle(transform.rotation, southRoom) == 0f) // check camera orientation
	    {
		    targetPosition = southRoomZoom;
	    }
	    else if (Quaternion.Angle(transform.rotation, westRoom) == 0f)
	    {
		    targetPosition = westRoomZoom;
	    }
	    else
	    {
		    print("error: not a recognized angle");
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

    public void checkUnderCushion()
    {
	    if (transform.position != westRoomZoom) // don't move cushion unless zoomed in
	    {
		    return;
	    }
	    targetPosition = new Vector3(-6.139999866485596f, 2.0999999046325685f, -2.700000047683716f);
	    targetRotation = Quaternion.Euler(40.9f, 240.1f, 0f);
	    rotateSpeed = 10f;
	    StartZoom();
	    StartRotation();
	    rotateSpeed = 100f; // change rotate speed back to original
    }
}
