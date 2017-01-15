using UnityEngine;
using System.Collections;
using EasyEditor;

public class TutorialMissions : MonoBehaviour {

	// This script handles teh activaiton or deactivation of the references game objects.
	// they can be in order or set at any order.


	public bool missionTriggerInOrder;


	[System.Serializable]
	public class Missions
	{
		public GameObject gObj;
		public bool activate;		// true for activate, false to Deactivate.
	};

	public Missions[] mission;


	public int actNext = 0;

	public int ActNext
	{
		get{return actNext; }
		set
		{
			actNext++;
		
			if (mission [actNext].activate == true) {
				mission [actNext].gObj.gameObject.SetActive (true);
			} else 
			{
				mission [actNext].gObj.gameObject.SetActive (false);
			}
		
		}

	}









	void Start()
	{
		if (missionTriggerInOrder) 
		{
			DeactivateMissions ();
		}
		
	}




	// Deactivates all missions minus number 2 if missionTriggerInOrder
	public void DeactivateMissions()	
	{
		// turn off all triggers minus the first one
		for (int i =1; i< mission.Length; i++)
		{

			mission [i].gObj.gameObject.SetActive (false);

		}

	}



	public void TriggerAction(int index, bool action)
	{


		mission [index].gObj.gameObject.SetActive (action);

		
	}




}
