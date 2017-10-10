using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	public string		MyColor		 		= "Not Set"				;
	public GameObject	SelectionOutline 	= null					;
	public GameObject	TheMenu			 	= null					;
	public GameObject	TheGame			 	= null					;
	public string		ClickAnimation 		= "Button_JustClicked"	;
	public float		SFXPitchMin 		= 0.9f					;
	public float		SFXPitchMax 		= 1.1f					;

//	[Header("Development Tools")]
//	public bool			DebugMode 			= false					;

	void Start ()
	{
		CheckName ();

		if ( SelectionOutline == null )
			Debug.LogWarning ("StartButton [" + gameObject.name + "]: Selector not Selected.");
	}

	void OnMouseUp ()
	{
		if (!SelectionOutline.activeInHierarchy)
		{
			PlayClickSound			();
			SetSelection			();
			PlayClickAnimation		();
			SetCurrentSelectedColor ();
		}
		else
		{
			BeginGame				();
		}
	}

	public void SetSelection ()
	{
		GameObject PrevSelector = GameObject.FindGameObjectWithTag ("Selector");

		if ( PrevSelector != null ) PrevSelector.SetActive (false);

		SelectionOutline.SetActive (true);
	}

	public void PlayClickSound ()
	{
		gameObject.GetComponentInParent<AudioSource> ().pitch = Random.Range (SFXPitchMin, SFXPitchMax);
		gameObject.GetComponentInParent<AudioSource> ().PlayOneShot (gameObject.GetComponentInParent<AudioSource> ().clip);
	}

	public void PlayClickAnimation ()
	{
		gameObject.GetComponent<Animator> ().Play (ClickAnimation);
	}

	public void SetCurrentSelectedColor ()
	{
		PlayerPrefs.SetString ("SelectedColor_Name"	, MyColor												  );
		PlayerPrefs.SetFloat  ("SelectedColor_R"	, gameObject.GetComponent<MeshRenderer>().material.color.r);
		PlayerPrefs.SetFloat  ("SelectedColor_G"	, gameObject.GetComponent<MeshRenderer>().material.color.g);
		PlayerPrefs.SetFloat  ("SelectedColor_B"	, gameObject.GetComponent<MeshRenderer>().material.color.b);
	}

	private void CheckName ()
	{
		if (MyColor.Equals ("Not Set"))
		{
			int Start 	= 15																;
			int Len 	= gameObject.GetComponent<MeshRenderer> ().material.name.Length - 25;
			MyColor = gameObject.GetComponent<MeshRenderer> ().material.name.Substring (Start, Len	);
			//if ( End >  Start ) MyColor = gameObject.GetComponent<MeshRenderer> ().material.name.Substring (Start, End	);
			//if ( End <= Start ) MyColor = gameObject.GetComponent<MeshRenderer> ().material.name.Substring (Start		);
		}
	}

	public void BeginGame ()
	{
		PlayerPrefs.SetInt ("CurrentGameScore", 0);

		TheGame.SetActive (true );
		TheMenu.SetActive (false);
	}
}
