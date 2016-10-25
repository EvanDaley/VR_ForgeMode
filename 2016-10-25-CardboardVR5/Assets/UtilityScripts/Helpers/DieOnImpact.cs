using UnityEngine;
using System.Collections;

public class DieOnImpact : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag != gameObject.tag)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag != gameObject.tag)
			Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag != gameObject.tag)
			Destroy (gameObject);
	}
}
