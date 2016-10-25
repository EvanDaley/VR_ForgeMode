using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {
	bool hasPressed = false;
	public float introLength = 7.1f;

	void Update () 
	{
		// if the user is trying to skip the intro load next
		if(Input.touchCount > 0 || Input.GetMouseButton(0))
		{
			//LoadNext ();
		}

		// if the intro is finished load next
		if (Time.time > introLength)
		{
			LoadNext ();
		}
	}

	public void LoadNext()
	{
		if (hasPressed == false)
		{
			SceneManager.LoadScene (1);
			hasPressed = true;
		}
	}
}
