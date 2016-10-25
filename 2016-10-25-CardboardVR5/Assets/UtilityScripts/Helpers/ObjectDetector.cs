using UnityEngine;
using System.Collections;

public class ObjectDetector : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		transform.parent.BroadcastMessage ("DetectObject", other.gameObject, SendMessageOptions.DontRequireReceiver);
	}
}
