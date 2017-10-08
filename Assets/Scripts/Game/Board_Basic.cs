using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_Basic : MonoBehaviour {
	[Range(0, 100)]
	public int			PercentageOfCorrectColor 	=	20			;
	public Material[]	AllColors					=	null		;
	public Color	  	SelectedColor				=	Color.black	;
	public int	  		SelectedMatIndex			=	-1			;

	void Start ()
	{
		InitializeBoard ();
	}

	public void InitializeBoard ()
	{
		UpdateColor ();

		GameObject[] Buttons = GameObject.FindGameObjectsWithTag ("Button");

		foreach (GameObject Butt in Buttons)
		{
			if (Random.Range (0, 100) <= PercentageOfCorrectColor)
			{
				 SetCorrectColor (Butt);
			}
			else SetRandomColor	 (Butt);

			Butt.GetComponent<Button> ().SetColors ();
		}
	}

	public void SetCorrectColor (GameObject Butt)
	{
		Butt.GetComponent<MeshRenderer>().material = AllColors[SelectedMatIndex];
	}

	public void SetRandomColor (GameObject Butt)
	{
		int RandomIndex = -1;

		do 
		{
			RandomIndex = Random.Range (0, AllColors.Length);
		}
		while (RandomIndex == SelectedMatIndex);

		Butt.GetComponent<MeshRenderer>().material = AllColors[RandomIndex];
	}

	public void UpdateColor ()
	{
		SelectedColor.r = PlayerPrefs.GetFloat 	("SelectedColor_R");
		SelectedColor.g = PlayerPrefs.GetFloat 	("SelectedColor_G");
		SelectedColor.b = PlayerPrefs.GetFloat 	("SelectedColor_B");

		for (int i = 0; i < AllColors.Length; i++)
		{
			if (AllColors [i].GetColor ("_EmissionColor") == SelectedColor)
			{
				SelectedMatIndex = i;
				break;
			}
		}
	}
}
