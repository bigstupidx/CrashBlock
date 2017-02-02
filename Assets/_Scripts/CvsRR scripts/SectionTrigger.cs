using UnityEngine;
using System.Collections;

public class SectionTrigger : MonoBehaviour {

	[SerializeField]
	private BoxCollider box_col;
	[SerializeField]
	private Color color = new Color (0,0,1,190);

	[SerializeField]
	private SpawnSection spawnSection_ref;



	void OnDrawGizmos ()
	{
		if(box_col == null)
		box_col = gameObject.GetComponent<BoxCollider> ();


		Gizmos.color = color;
		Gizmos.DrawCube(transform.position, box_col.size);
	}


	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "Player") 
		{
			spawnSection_ref.SpawnNpcs ();

			this.gameObject.SetActive (false);
		}



	}

	

}
