using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public int		  TheScore  = -1			;
	public GameObject ScoreText = null			;
	public GameObject ScoreBG	= null			;
	public Vector3 	  BGDefSize	= Vector3.zero	;
	public Vector3 	  BGBigSize	= Vector3.zero	;
	public Color	  CurrentColor= Color.black	;

	void Start ()
	{
		CheckGOs ();
	}

	void Update ()
	{
		UpdateScore ();
		UpdateColor ();
	}

	public void UpdateScore ()
	{
		TheScore = PlayerPrefs.GetInt ("CurrentGameScore");

		if (TheScore < 100)
		{
			gameObject.GetComponent<TextMesh> ().text = TheScore.ToString ("00");
			ScoreBG.transform.localScale = BGDefSize;
		}
		else if (TheScore >= 100)
		{
			gameObject.GetComponent<TextMesh> ().text = TheScore.ToString ("000");
			ScoreBG.transform.localScale = BGBigSize;
		}
	}

	private void CheckGOs ()
	{
		if (ScoreText == null)
			ScoreText = gameObject;

		if (ScoreText.GetComponent<TextMesh> () == null)
			ScoreText.AddComponent<TextMesh> ();
	}

	public void UpdateColor ()
	{
		CurrentColor.r = PlayerPrefs.GetFloat 	("SelectedColor_R")		;
		CurrentColor.g = PlayerPrefs.GetFloat 	("SelectedColor_G")		;
		CurrentColor.b = PlayerPrefs.GetFloat 	("SelectedColor_B")		;

		ScoreBG.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", CurrentColor);
	}
}
