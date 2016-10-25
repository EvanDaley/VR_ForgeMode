using UnityEngine;
using System.Collections;

public class MenuOptionTarget : LookTarget 
{
	public MoveMenuOption moveMenuOption;

	public override  void FireEvent()
	{
		MenuController.Instance.MoveCharacter (moveMenuOption);
	}
}

public enum MoveMenuOption
{
	forward,
	left,
	right,
	backward
}