using UnityEngine;
using System.Collections;

public class PhysicsPlayer : MonoBehaviour {

	private Rigidbody rbody;

	private Vector3 moveDirection;
	public float moveSpeed = 2f;
	public float moveDuration = 1f;
	private float moveCooldown = 0f;
	private bool moving = false;

	private Vector3 rotateDirection;
	public float rotateSpeed = 2f;
	public float rotateDuration = .5f;
	private float rotateCooldown;
	private bool rotating = false;

	public bool simulateHeadMovement = false;
	public float moveSimulationSpeed = 5f;

	void Start () 
	{
		rbody = GetComponent<Rigidbody> ();
	}
	
	void Update () 
	{
		if (Time.time < moveCooldown)
		{
			Move ();
		}

		//Vector3 newRotation = new Vector3 (0, Camera.main.transform.eulerAngles.y, 0);
		//transform.eulerAngles = newRotation;

		if (simulateHeadMovement)
		{
			if (Input.GetAxis ("Vertical") > .1f)
			{
				//print ("up");
				//SetMove (Camera.main.transform.forward);
				Camera.main.transform.parent.Rotate (-Vector3.right * moveSimulationSpeed);
			}

			if (Input.GetAxis ("Vertical") < -.1f)
			{
				//print ("down");
				//SetMove (-Camera.main.transform.forward);
				Camera.main.transform.parent.Rotate (Vector3.right * moveSimulationSpeed);

			}

			if (Input.GetAxis ("Horizontal") > .1f)
			{
				//print ("right");
				//Rotate(Vector3.up);
				Camera.main.transform.parent.Rotate (Vector3.up * moveSimulationSpeed);

			}

			if (Input.GetAxis ("Horizontal") < -.1f)
			{
				//print ("left");
				//Rotate(Vector3.down);
				Camera.main.transform.parent.Rotate (Vector3.down * moveSimulationSpeed);

			}
		} else
		{
			if (Input.GetAxis ("Vertical") > .1f)
			{
				//print ("up");
				SetMove (Camera.main.transform.forward);
			}

			if (Input.GetAxis ("Vertical") < -.1f)
			{
				//print ("down");
				SetMove (-Camera.main.transform.forward);
			}

			if (Input.GetAxis ("Horizontal") > .1f)
			{
				//print ("right");
				//Rotate(Vector3.up);
				SetMove (Camera.main.transform.right);
			}

			if (Input.GetAxis ("Horizontal") < -.1f)
			{
				//print ("left");
				//Rotate(Vector3.down);
				SetMove (-Camera.main.transform.right);
			}
		}
	}

	public void SetMove(Vector3 direction)
	{
		moving = true;
		moveDirection = direction;
		moveCooldown = Time.time + moveDuration;
	}

	void Move()
	{
		Vector3 newPosition = Vector3.MoveTowards (transform.position, transform.position + moveDirection, Time.deltaTime * moveSpeed);
		transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
	}

	public void Rotate(Vector3 rotateDirection)
	{
		transform.Rotate (rotateDirection * rotateSpeed);
	}


}
