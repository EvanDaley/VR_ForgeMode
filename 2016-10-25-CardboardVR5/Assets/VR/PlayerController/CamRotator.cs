using UnityEngine;
using System.Collections;

public class CamRotator : MonoBehaviour {

	public float rotationSpeed = 4f;

	public Transform cameraPlaceholder;
	public Transform player;
	
	void Update () 
	{
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			RotateCamera (-player.transform.up);
		}

		if (Input.GetKey (KeyCode.RightArrow))
		{
			RotateCamera (player.transform.up);
		}

		if (Input.GetKey (KeyCode.UpArrow))
		{
			RotateCamera (-player.transform.right);
		}

		if (Input.GetKey (KeyCode.DownArrow))
		{
			RotateCamera (player.transform.right);
		}
			
		if (Input.GetKey (KeyCode.RightShift))
		{
			ResetCamRotation ();
		}
	}

	public void ResetCamRotation()
	{
		cameraPlaceholder.rotation = player.rotation;
	}

	public void RotateCamera(Vector3 rotateDirection)
	{
		cameraPlaceholder.Rotate (rotateDirection * rotationSpeed * Time.deltaTime);
	}
}
