using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextLevelOnImpact : MonoBehaviour {

	public int layerOfVictory = 9;
	public int levelToLoad = 3;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == layerOfVictory)
		{
			SceneManager.LoadScene (levelToLoad);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == layerOfVictory)
		{
			SceneManager.LoadScene (levelToLoad);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == layerOfVictory)
		{
			SceneManager.LoadScene (levelToLoad);
		}
	}
}
