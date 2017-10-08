using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public Color	  ButtonColor	= Color.black	;
	public Color	  SelectedColor	= Color.black	;

	void OnMouseDown()
	{
		CheckMatch ();
	}

	private void CheckMatch ()
	{
		if (ButtonColor == SelectedColor)
		{
			PlayerPrefs.SetInt ("CurrentGameScore", PlayerPrefs.GetInt ("CurrentGameScore") + 1);

			if (PlayerPrefs.GetInt("CurrentGameScore") > PlayerPrefs.GetInt("BestScore_" + PlayerPrefs.GetString("SelectedColor_Name")))
			{
				PlayerPrefs.SetInt ("BestScore_" + PlayerPrefs.GetString("SelectedColor_Name"), PlayerPrefs.GetInt("CurrentGameScore"));
			}
		}
	}

	public void SetColors ()
	{
		SelectedColor.r = PlayerPrefs.GetFloat 	("SelectedColor_R");
		SelectedColor.g = PlayerPrefs.GetFloat 	("SelectedColor_G");
		SelectedColor.b = PlayerPrefs.GetFloat 	("SelectedColor_B");

		ButtonColor = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
	}
}
