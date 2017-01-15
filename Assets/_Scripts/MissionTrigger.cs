using UnityEngine;
using System.Collections;
using EasyEditor;

public class MissionTrigger : MonoBehaviour {
	// this gameObjects should not be inside a container in the gameobjects.
	// the missions script acces the root game object, so it would disable important parts of the game.


	[Header("Set this number for Order missions like tutorial")]
	[SerializeField]
	private int triggerNumber;

	[SerializeField]
	private BoxCollider col;

	[SerializeField]
	private SphereCollider sCol;
	[SerializeField]
	private TutorialMissions tutMis_ref;

	void Awake()
	{
		if (tutMis_ref == null)
		{
			tutMis_ref = GameObject.FindGameObjectWithTag("Database").GetComponent<TutorialMissions>();
		}
	}


	// when player hits the trigger
	void OnTriggerEnter (Collider other)
	{

		switch (other.gameObject.tag)
		{

			case "Player":

				if( tutMis_ref != null)
				{
					tutMis_ref. TriggerAction (triggerNumber, false );

					// call enxt mission trigger
					tutMis_ref.ActNext += 1;

				}
				
			break;

		}
	
	}



}
