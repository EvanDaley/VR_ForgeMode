using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelTrigger : MonoBehaviour {

	public int sceneToLoad = 0;
	public float loadAfterTime = 0;
	private float timeToLoad;

	void Start () 
	{
		if (loadAfterTime != 0)
			timeToLoad = Time.time + loadAfterTime;
		else
			timeToLoad = float.MaxValue;
	}
	
	void Update () 
	{
		//print (Time.time);
		if (Time.time > timeToLoad)
		{
			LoadScene ();
		}
	}

	public void LoadScene()
	{
		SceneManager.LoadScene (sceneToLoad);
	}
}
