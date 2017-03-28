using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour
{
	[Header("Drag the target arrow here"), SerializeField]
	public Transform target;
	[SerializeField]
	private PlayerJumpPad playerJump_ref;
	[SerializeField]
	private DataComps dataComp;

	[Header("Line Gizmo Colour"),SerializeField]
	private Color lineColour;

	[Header("Particles transform"),SerializeField]
	private Transform particlesTransform;


	// load scripts
	void Start()
	{
		LoadReferences ();
	}



	void OnTriggerEnter (Collider col)
	{

		switch (col.gameObject.tag)
		{
			case  "Player":
				playerJump_ref.TargetPosition = target.position;
				//dataComp.playerSpeaker_ref.PlaySfx = 0;
				
			break;
		
			case  "NPC":
				playerJump_ref.TargetPosition = target.position;
				//dataComp.playerSpeaker_ref.PlaySfx = 0;

			break;
		
		
		}


	}



	// draw a line between teh jump pad and the target point
	void OnDrawGizmos ()
	{
		Gizmos.color = lineColour;
		Gizmos.DrawLine (transform.position, target.position);

	}
		


	void Update()
	{
		if( particlesTransform)
		particlesTransform.transform.LookAt (target);
	}

	





	void LoadReferences()
	{
		if (dataComp == null) 
		{
			dataComp = GameObject.FindGameObjectWithTag ("DataBase").GetComponent<DataComps> ();
		}

		if (dataComp && playerJump_ref == null) 
		{
			playerJump_ref = dataComp.fpsPlayer_ref.GetComponent<PlayerJumpPad> ();
		}

		// if there si a mesh renderer, turn off the Arrow or target graphic
		if(target.gameObject.GetComponent<MeshRenderer> ())
			target.gameObject.GetComponent<MeshRenderer> ().enabled = false;

	}



}