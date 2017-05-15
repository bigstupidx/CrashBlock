using UnityEngine;
using System.Collections;

public class ElementalMissileImpact : MonoBehaviour {

	[SerializeField]
	private ElementalMissile missile_ref;



	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer( "Player")) 
		{
			missile_ref.MissileCollided (gameObject.transform);
			gameObject.GetComponent<SphereCollider> ().enabled = false;
		}

		if (collision.gameObject.layer == LayerMask.NameToLayer("Default")) 
		{
			missile_ref.MissileCollided (gameObject.transform);
			gameObject.GetComponent<SphereCollider> ().enabled = false;
		}

		//gameObject.GetComponent<SphereCollider> ().enabled = false;

	}



}
