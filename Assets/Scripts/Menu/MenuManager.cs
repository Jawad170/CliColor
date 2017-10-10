using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	[Header("On Start")]
	public	bool	FadeButtonsIn			=	false				;
	public	bool	RandomlySelectButtons	=	false				;
	public	float	Interval				=	0.1f				;
	public	string	FadeAnim				=	"Button_FadeIn"		;
	public	string	HideAnim				=	"Button_Hide"		;

	void Start ()
	{
		ResetMenu ();
	}

	void Update ()
	{
		
	}

	public void ResetMenu ()
	{
		StartCoroutine("FadeButtons");
	}

	public IEnumerator FadeButtons ()
	{
		if (FadeButtonsIn)
		{
			GameObject[] Butts = GameObject.FindGameObjectsWithTag ("Button");

			int[] nums = new int[Butts.Length];

			HideAll (Butts);

			if (RandomlySelectButtons)
			{
				for (int i = 0; i < Butts.Length; i++)
				{
					int index = -1;

					do
					{
						index = Random.Range(0, Butts.Length);
					} 
					while (IsChecked(nums, index));

					nums [index] = 1;
					Butts[index].GetComponent<Animator> ().Play (FadeAnim);

					yield return new WaitForSecondsRealtime (Interval);
				}

			}
			else
			{
				foreach (GameObject Butt in Butts)
				{
					Butt.GetComponent<Animator> ().Play (FadeAnim);

					yield return new WaitForSecondsRealtime (Interval);
				}
			}
		}
	}

	private void HideAll(GameObject[] Butts)
	{
		foreach (GameObject Butt in Butts)
		{
			Butt.GetComponent<Animator> ().Play (HideAnim);
		}
	}

	private bool IsChecked(int[] nums, int i)
	{
		if ( nums[i] == 1 ) return true;

		return false;
	}
}
