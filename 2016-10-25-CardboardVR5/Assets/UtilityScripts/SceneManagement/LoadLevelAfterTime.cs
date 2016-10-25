using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour {

	public int levelToLoad = 0;
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

	void LoadNext()
	{
		if (hasPressed == false)
		{
			SceneManager.LoadScene (levelToLoad);
			hasPressed = true;
		}
	}
}
