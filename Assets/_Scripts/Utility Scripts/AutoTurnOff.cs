using UnityEngine;
using System.Collections;

public class AutoTurnOff : MonoBehaviour {

	[SerializeField]
	private GameObject thisGameobj;




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
		yield return new WaitForSeconds (3.0f);


		if (thisGameobj!= null)
		{
			thisGameobj.SetActive (false);
		}




	}
}
