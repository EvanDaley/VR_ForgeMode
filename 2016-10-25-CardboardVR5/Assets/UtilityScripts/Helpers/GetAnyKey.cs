using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetAnyKey : MonoBehaviour {

	public Text textObject;
	
	void Update () 
	{
		if(Input.anyKeyDown){

			print(Input.inputString);

			if (textObject != null)
			{
				textObject.text = Input.inputString;
			}
		}
	}
}
