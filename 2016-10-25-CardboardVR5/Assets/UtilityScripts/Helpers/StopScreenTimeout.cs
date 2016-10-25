using UnityEngine;
using System.Collections;

public class StopScreenTimeout : MonoBehaviour {

	void Start () 
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

}
