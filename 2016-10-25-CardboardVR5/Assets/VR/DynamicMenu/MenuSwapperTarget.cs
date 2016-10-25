using UnityEngine;
using System.Collections;

public class MenuSwapperTarget : LookTarget 
{
	public SubMenuType menuToActivate;

	public override  void FireEvent()
	{
		MenuController.Instance.SwapToMenu (menuToActivate);
	}
}

public enum SubMenuType
{
	movePlayer,
	translateCursor,
	rotateCursor,
	scaleCursor,
	options,
	create,
	escape,
	center
}