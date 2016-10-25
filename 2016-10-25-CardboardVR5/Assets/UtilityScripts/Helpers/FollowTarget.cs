using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform target;

	private Vector3 offset;
	//private Vector3 originalPosition;

	public bool lockX = false;
	public bool lockY = false;
	public bool lockZ = false;

	void Start()
	{
		offset = transform.position - target.position;
		//originalPosition = transform.position;
	}

	void Update ()
	{
		float x = (lockX) ? 0 : target.position.x + offset.x;
		float y = (lockY) ? 0 : target.position.y + offset.y;
		float z = (lockZ) ? 0 : target.position.z + offset.z;

		transform.position = new Vector3 (x, y, z);
	}
}
