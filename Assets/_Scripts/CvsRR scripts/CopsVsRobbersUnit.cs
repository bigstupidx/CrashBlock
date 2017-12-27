using UnityEngine;
using System.Collections;

public class CopsVsRobbersUnit : MonoBehaviour {

	[SerializeField]
	private GM_CopsvsRobbers gameManager_ref;
	[SerializeField]
	public CopsVsRobbers unitType;
	[SerializeField]
	private AI aI_ref;

	void OnEnable()
	{

		gameManager_ref = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GM_CopsvsRobbers>();

		aI_ref = gameObject.GetComponent<AI> ();

        Invoke ("UpdateTeam", 1.0f);
	}

	void UpdateTeam()
	{

		switch(unitType)
		{
			// if this unit is a cop
			case CopsVsRobbers.Cop:
			{
					// if player team is cops
				if (gameManager_ref.playerTeam == CopsVsRobbers.Cop) 
				{
					aI_ref.ChangeFaction (1);
				}

				// if player team is robbers
				if (gameManager_ref.playerTeam == CopsVsRobbers.Robber) 
				{
					aI_ref.ChangeFaction (3);
				}


			}
			break;

			// if this unit is a robber
			case CopsVsRobbers.Robber:
			{
				// if player team is cops
				if (gameManager_ref.playerTeam == CopsVsRobbers.Cop) 
				{
					aI_ref.ChangeFaction (3);
				}

				// if player team is robbers
				if (gameManager_ref.playerTeam == CopsVsRobbers.Robber) 
				{
					
					aI_ref.ChangeFaction (1);
				}


			}
			break;

		}




	}



}
