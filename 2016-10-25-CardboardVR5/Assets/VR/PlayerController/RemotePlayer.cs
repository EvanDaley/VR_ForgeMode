using UnityEngine;
using System.Collections;

public class RemotePlayer : MonoBehaviour {

	private Rigidbody rbody;

	public float moveSpeed = 2f;
	private bool moving = false;

	public float rotateSpeed = 2f;
	private bool rotating = false;

	void Start () 
	{
		rbody = GetComponent<Rigidbody> ();
	}
	
	void Update () 
	{
		if (Input.GetAxis ("Vertical") > .1f)
		{
			Move (Camera.main.transform.forward);
		}

		if (Input.GetAxis ("Vertical") < -.1f)
		{
			Move (-Camera.main.transform.forward);
		}

		if (Input.GetAxis ("Horizontal") > .1f)
		{
			Move (Camera.main.transform.right);
		}

		if (Input.GetAxis ("Horizontal") < -.1f)
		{
			Move (-Camera.main.transform.right);
		}
	}

	public void Move(Vector3 direction)
	{
		moving = true;

		Vector3 newPosition = Vector3.MoveTowards (transform.position, transform.position + direction, Time.deltaTime * moveSpeed);
		transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
	}

	public void Rotate(Vector3 rotateDirection)
	{
		transform.Rotate (rotateDirection * rotateSpeed);
	}
}
