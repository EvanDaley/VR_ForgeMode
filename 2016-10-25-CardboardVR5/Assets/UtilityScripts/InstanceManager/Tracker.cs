using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tracker : MonoBehaviour {

	public static Tracker Instance;

	List<Tag> actors = new List<Tag>();
	public int numberOfCalls = 0;
	public int numberOfLoops = 0;

	void Awake()
	{
		Instance = this;
	}

	public void ActivatePlayersOnTeam(int team)
	{
		print ("ActivatePlayersOnTeam has not been implemented in this version.");
	}

	public void DestroyNonPlayerActors()
	{
		foreach (Tag tag in actors)
		{
			if (tag != null)
			{
				if (tag.teamNumber != 1 && tag.teamNumber != -1)
				{
					Destroy (tag.gameObject);
				}
			}
		}
	}

	public int GetNumActorsOnSpecTeam(int team)
	{
		int count = 0;

		foreach (Tag tag in actors)
		{
			if (tag != null)
			{
				if (tag.teamNumber == team)
				{
					if(tag.gameObject.activeSelf)
						count++;
				}
			}
		}

		return count;
	}

	public int GetNumActorsNotOnSpecTeam(int team)
	{
		int count = 0;

		foreach (Tag tag in actors)
		{
			if (tag != null)
			{
				if (tag.teamNumber != team)
				{
					count++;
				}
			}
		}

		return count;
	}

	public void RegisterActor(Tag tag)
	{
		//print ("Adding actor: " + tag.name);
		actors.Add (tag);
	}

	public void DeRegisterActor(Tag tag)
	{
		//print ("Removing actor: " + tag.name);
		actors.Remove (tag);
	}

	public Tag GetClosestEnemy(Tag me)
	{
		return GetClosestEnemy (me.transform.position, me.teamNumber);
	}

	public Tag GetClosestEnemy(Vector3 position, int teamId)
	{
		//if(numberOfCalls % 10 == 0)
		//	print("Called GetClosestEnemy (" + numberOfCalls + ") times. Function stepped through (" + numberOfLoops + ") loops.");

		numberOfCalls++;
		float curDist = 0;
		float minDistance = float.MaxValue;
		Tag closestEnemy = null;

		foreach (Tag tag in actors)
		{
			if (tag != null)
			{
				if (tag.teamNumber != teamId && tag.teamNumber != -1)
				{
					curDist = Vector3.Distance (position, tag.transform.position);
					if (curDist < minDistance)
					{
						minDistance = curDist;
						closestEnemy = tag;

						numberOfLoops++;

						if (curDist < 2)
							return closestEnemy;
					}
				}
			}
		}

		return closestEnemy;
	}

	public Tag GetClosestFriend(Vector3 position, int teamId)
	{
		numberOfCalls++;
		float curDist = 0;
		float minDistance = float.MaxValue;
		Tag closestFriend = null;

		// every once and a while we need to remove phantom objects
		if(numberOfCalls % 10 == 0)
			PruneList ();

		foreach (Tag tag in actors)
		{
			if (tag != null)
			{

				if (tag.teamNumber == teamId)
				{
					curDist = Vector3.Distance (position, tag.transform.position);
					if (curDist < minDistance)
					{
						minDistance = curDist;
						closestFriend = tag;

						numberOfLoops++;

						if (curDist < 2)
							return closestFriend;
					}
				}
			}
		}

		return closestFriend;
	}

	public void PruneList()
	{
		for (int i = 0; i < actors.Count; i++)
		{
			Tag tag = actors [i];
			if (tag != null)
			{
				// do nothing
			}
			else
			{
				print ("Found a null entry in actors list");
				actors.RemoveAt (i);
			}
		}
	}

}
