using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public	Color	ButtonColor				= Color.black			;
	public	Color	SelectedColor			= Color.black			;
	public	string	CorrectAnim				= "Button_CorrectNGo"	;
	public	string	WrongAnim				= "Button_Err"			;

	void Start ()
	{
		if (gameObject.GetComponent<Animator> () == null)
			gameObject.AddComponent<Animator> ();
	}

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

			gameObject.GetComponent<Animator> ().Play (CorrectAnim);
		}
		else
		{
			gameObject.GetComponent<Animator> ().Play (WrongAnim);
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
