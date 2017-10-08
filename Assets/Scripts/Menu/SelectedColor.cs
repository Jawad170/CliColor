using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedColor : MonoBehaviour {

	public GameObject	ScoreText		= null			;
	public Color		CurrentColor	= Color.black	;

	void Update ()
	{
		UpdateName  ();
		UpdateColor ();
		UpdateScore ();
	}

	public void  UpdateName ()
	{
		string SelectedColor = PlayerPrefs.GetString ("SelectedColor_Name");
		//Retrieve Localized Name Here perhaps?
		gameObject.GetComponent<TextMesh> ().text = SelectedColor;
	}

	public void UpdateColor ()
	{
		CurrentColor.r = PlayerPrefs.GetFloat 	("SelectedColor_R")		;
		CurrentColor.g = PlayerPrefs.GetFloat 	("SelectedColor_G")		;
		CurrentColor.b = PlayerPrefs.GetFloat 	("SelectedColor_B")		;

		gameObject.GetComponent<TextMesh>		().color = CurrentColor	;
		ScoreText.GetComponent<TextMesh>		().color = CurrentColor	;
	}

	public void UpdateScore ()
	{
		if ( CurrentColor != Color.black)
			ScoreText.GetComponent<TextMesh> ().text = PlayerPrefs.GetInt ("BestScore_" + PlayerPrefs.GetString("SelectedColor_Name")).ToString();
	}
}
