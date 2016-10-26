using UnityEngine;
using System.Collections;

public class CreateMenuOptionTarget : LookTarget 
{
	public CreateMenuOption createMenuOption;

	public override  void FireEvent()
	{
		MenuController.Instance.PerformCreateMenuAction (createMenuOption);
	}
}

public enum CreateMenuOption
{
	next,
	prev
}
