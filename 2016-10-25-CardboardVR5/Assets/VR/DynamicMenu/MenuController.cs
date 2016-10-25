using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public PhysicsPlayer physicsPlayer;
	public GameObject cursor3d;
	public GameObject menu;

	public static MenuController Instance;
	private bool displayMenu = true;

	public float menuDelay = .4f;
	private float menuCooldown = 0;

	public bool DisplayMenu
	{
		get 
		{ 
			return displayMenu;
		}

		set
		{
			if (Time.time < menuCooldown)
				return;

			displayMenu = value;
			if (displayMenu == true)
			{
				menu.SetActive (true);
				CenterMenu ();
			} else
			{
				menu.SetActive (false);
			}

			menuCooldown = Time.time + menuDelay;
		}
	}

	void CenterMenu()
	{
		menu.transform.position = physicsPlayer.transform.position;

		Vector3 forward = new Vector3 (Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
		menu.transform.forward = forward;
	}

	void Awake()
	{
		Instance = this;
	}

	void LateUpdate()
	{
		if (GvrViewer.Instance.Triggered && displayMenu == false)
		{
			DisplayMenu = true;
		}
	}

	public void MoveCharacter(MoveMenuOption moveOption)
	{
		if (moveOption == MoveMenuOption.forward)
		{
			print ("forward");
			physicsPlayer.SetMove (Camera.main.transform.forward);
			//physicsPlayer.SetMove (physicsPlayer.transform.forward);
		}

		else if (moveOption == MoveMenuOption.backward)
		{
			print ("back");
			//physicsPlayer.SetMove (-physicsPlayer.transform.forward);
			physicsPlayer.SetMove (-Camera.main.transform.forward);

		}

		else if (moveOption == MoveMenuOption.left)
		{
			//physicsPlayer.SetMove (-physicsPlayer.transform.right);
			print ("left");
//			physicsPlayer.SetMove (-Camera.main.transform.right);
			physicsPlayer.Rotate (-Vector3.up);
		}

		else if (moveOption == MoveMenuOption.right)
		{
			print ("right");
			//physicsPlayer.SetMove (physicsPlayer.transform.right);
			//physicsPlayer.SetMove (Camera.main.transform.right);
			physicsPlayer.Rotate (Vector3.up);

		}
	}

	public void SwapToMenu(SubMenuType menuType)
	{
		if (menuType == SubMenuType.movePlayer)
		{
			print ("Switch to move");
			ResetCursorRotation ();

		}

		else if (menuType == SubMenuType.options)
		{
			print ("Switch to options");
			ResetCursorRotation ();

		}

		else if (menuType == SubMenuType.rotateCursor)
		{
			print ("Switch to rotate");
			ResetCursorRotation ();

		}

		else if (menuType == SubMenuType.scaleCursor)
		{
			print ("Switch to scale");
			ResetCursorRotation ();

		}

		else if (menuType == SubMenuType.translateCursor)
		{
			print ("Switch to translate");
			ResetCursorRotation ();
		}

		else if (menuType == SubMenuType.center)
		{
			print ("Center");
			CenterMenu ();
		}

		else if (menuType == SubMenuType.escape)
		{
			DisplayMenu = false;
		}
	}

	public void ResetCursorRotation()
	{
		if (cursor3d != null)
		{
			cursor3d.transform.rotation = Camera.main.transform.rotation;
			cursor3d.transform.localScale = Vector3.one;

		}
	}
}
