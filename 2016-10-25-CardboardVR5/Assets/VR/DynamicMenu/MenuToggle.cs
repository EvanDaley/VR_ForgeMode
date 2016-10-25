using UnityEngine;
using System.Collections;

public class MenuToggle : MonoBehaviour 
{
	private MeshRenderer mRenderer;

	void Start()
	{
		mRenderer = GetComponent<MeshRenderer> ();
	}

	void Update()
	{
		if (!mRenderer.isVisible)
		{
			MenuController.Instance.DisplayMenu = false;
		}
	}
}
