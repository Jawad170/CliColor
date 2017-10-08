using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public	float	MaximumTime 	=	10.0f	;
	public	float	StartTime 		=	10.0f	;
	public	float	CurrentTime		=	00.0f	;

	//private	bool	Paused			=	true	;

	void Start ()
	{
		if (CheckValues ())
		{
			Reset 		();
			StartTimer 	();
		}
	}

	public void Reset ()
	{
		CurrentTime = StartTime;

		SetBars ();
	}

	private void SetBars ()
	{
		float Pcnt = (CurrentTime / MaximumTime) * 100.0f;

		string Bars = "";

		for (float i = Pcnt; i >= 10.0f; i -= 10.0f)
		{
			Bars += "|";
		}

		gameObject.GetComponent<TextMesh> ().text = Bars;
	}

	public void StartTimer ()
	{
		StopCoroutine  ("Countdown");
		StartCoroutine ("Countdown");
	}

	public void PauseTimer ()
	{
		StopCoroutine  ("Countdown");
	}

	public IEnumerator Countdown ()
	{
		while (CurrentTime > 0.0f)
		{
			yield return new WaitForSecondsRealtime (0.1f);

			CurrentTime -= 0.1f;

			SetBars ();
		}

		CurrentTime = 0.0f;
	}

	private bool CheckValues()
	{
		if (StartTime > MaximumTime)
		{
			Debug.LogError ("Timer: Start Time can not be higher than Maximum Timer.");
			return false;
		}

		if (StartTime <= 0 || MaximumTime <= 0)
		{
			Debug.LogError ("Timer: Timer details can not be negative or zero.");
			return false;
		}

		return true;
	}
}
