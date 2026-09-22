using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 100f;
    private Quaternion targetRotation;

	void Start()
    {
        targetRotation = transform.rotation;
    }
	void Update()
	{
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
	}
    
	public void rotateCameraLeft()
    {
		targetRotation *= Quaternion.Euler(0, -90f, 0);
    }

    public void rotateCameraRight()
    {
       targetRotation *= Quaternion.Euler(0, 90f, 0);
    }
    
    public void zoomCamera(/*thing zooming in on?*/)
    {
        
    }
}
