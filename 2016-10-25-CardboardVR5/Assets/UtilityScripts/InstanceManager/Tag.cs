using UnityEngine;
using System.Collections;

public class Tag : MonoBehaviour {

	public int teamNumber;

	void Start()
	{
		Tracker.Instance.RegisterActor (this);
	}

	void OnDeath()
	{
		Tracker.Instance.DeRegisterActor (this);
	}
}