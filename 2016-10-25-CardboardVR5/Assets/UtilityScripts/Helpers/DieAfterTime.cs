using UnityEngine;
using System.Collections;

public class DieAfterTime : MonoBehaviour {

	public float lifeSpan = 1f;

	private float deathTime = float.MaxValue;

	void Start () 
	{
		// This sets a default death time, but can also be changed by outside gameobjects (i.e. text controller)
		SetDeathTime (Time.time + lifeSpan);
	}

	// This is sometimes called by other gameobjects
	public void SetDeathTime(float deathTime)
	{
		lifeSpan = deathTime - Time.time;
		this.deathTime = deathTime;
	}

	void Update () 
	{
		if (Time.time > deathTime)
			Destroy (gameObject);
	}
}
