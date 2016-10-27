using UnityEngine;
using System.Collections;

public class PushTowardReticle : MonoBehaviour {

	public bool applyForce = true;
	public float moveForce = 100f;
	public float maxSpeed = 10f;


	private Rigidbody rbody;

	void Start () 
	{
		rbody = GetComponent<Rigidbody> ();
	}
	
	void Update () 
	{
		if (applyForce)
		{
			float distance = Vector3.Distance (transform.position, Cursor3D.Instance.transform.position);
			if (distance > .05f)
			{
				Vector3 direction = Cursor3D.Instance.transform.position - transform.position;
				rbody.AddForce (direction * Time.deltaTime * moveForce);
			}
		}
	}
}
