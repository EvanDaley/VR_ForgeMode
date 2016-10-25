using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleTimedAudioController : MonoBehaviour {

	public CustomAudioEvent[] events;
	private float levelStartTime;
	private AudioSource audioSource;

	void Start()
	{
		levelStartTime = Time.time;
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		foreach (CustomAudioEvent audioEvent in events)
		{
			if ((Time.time - levelStartTime) > audioEvent.startTime)
			{
				if (audioSource != null)
				{
					if (audioSource.isPlaying == false)
					{
						audioSource.PlayOneShot(audioEvent.clip);
						audioEvent.shouldPlay = false;
					}
				}
			}
		}
	}
}

[System.Serializable]
public class CustomAudioEvent
{
	public bool shouldPlay = true;
	public float startTime;
	public AudioClip clip;
}