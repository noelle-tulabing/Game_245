using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{
    private float speed = 100f;
    private Quaternion targetRotation;
    Coroutine rotateRoutine;

    void Start()
    {
        transform.position = new Vector3(0f, 3.68f, 0f);
        transform.rotation = Quaternion.Euler(50f, -30f, 0f);
        targetRotation = transform.rotation;
    }

    public void rotateLightLeft()
    {
        targetRotation *= Quaternion.Euler(1f, -90f, 1f);
        StartRotation();
    }

    public void rotateLightRight()
    {
        targetRotation *= Quaternion.Euler(1, 90f, 1);
        StartRotation();
    }

    void StartRotation()
    {
        // Stop any rotation already in progress so two coroutines don't fight
        if (rotateRoutine != null)
            StopCoroutine(rotateRoutine);
        rotateRoutine = StartCoroutine(rotateLight());
    }

    IEnumerator rotateLight()
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
}
