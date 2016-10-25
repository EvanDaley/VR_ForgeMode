using UnityEngine;
using System.Collections;

public class MimicCameraRotation : MonoBehaviour {
	
	void Update () 
	{
		transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
	}
}
