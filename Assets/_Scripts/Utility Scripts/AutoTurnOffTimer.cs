using UnityEngine;
using System.Collections;

public class AutoTurnOffTimer : MonoBehaviour {

	[SerializeField]
	private GameObject thisGameobj;
	[SerializeField]
	private float timer;




	void OnEnable()
	{
		if ( thisGameobj == null)
		{
			thisGameobj=this.gameObject;
		}


		StartCoroutine (TurnOffCo());


	}


	IEnumerator TurnOffCo()
	{
		yield return new WaitForSeconds (timer);


		if (thisGameobj!= null)
		{
			thisGameobj.SetActive (false);
		}




	}
}
