using UnityEngine;
using System.Collections;


public class CushionInteraction : MonoBehaviour, IClickable
{
    private float speed = 5f;
    private Vector3 startingPosition = new Vector3(-7.739981174468994f, 0.8652756214141846f, -3.63797664642334f);
    private Vector3 raisedPosition = new Vector3(-7.739981174468994f, 2.049999952316284f, -3.63797664642334f);
    private Vector3 targetPosition;
    private bool cushionUp;
    
    public CameraController cameraController;
    Coroutine moveCoroutine;
    void Start()
    {
       transform.position = startingPosition;
       cushionUp = false;
    }

    void Update()
    {
        if (cameraController.getCurrentPosition() != new Vector3(-6.139999866485596f, 2.0999999046325685f, -2.700000047683716f) &&
            cushionUp)
        {
            targetPosition = startingPosition;
            StartMovement();
            cushionUp = false;
        }
    }
    public void OnClick()
    {
        if (cameraController.getCurrentPosition() != new Vector3(-5f, 2f, -2f) && cameraController.getCurrentPosition() != new Vector3(-6.139999866485596f, 2.0999999046325685f, -2.700000047683716f))
        {
            return;
        }
        if (cushionUp)
        {
            targetPosition = startingPosition;
        }
        else
        {
            targetPosition = raisedPosition;
        }
        StartMovement();
        cameraController.checkUnderCushion();
        cushionUp = !cushionUp;
    }

    void StartMovement()
    {
        // Stop any rotation already in progress so two coroutines don't fight
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        moveCoroutine = StartCoroutine(moveCushion());
    }
    
    IEnumerator moveCushion()
    {
        // Keep rotating until we've reached the target
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null; // wait one frame
        }
        transform.position = targetPosition; // snap to exact final value
        moveCoroutine = null;
    }
}
