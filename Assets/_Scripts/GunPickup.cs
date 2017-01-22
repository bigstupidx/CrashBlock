using UnityEngine;
using System.Collections;

public class GunPickup : MonoBehaviour {


	public DataComps dataComps;
	public Collider col;
	public int weaponIndex;

	// load datacomps
	void Awake()
	{
		if (dataComps == null) 
		{
			dataComps = GameObject.FindGameObjectWithTag ("DataBase").GetComponent<DataComps>();
		}
	}


	//
	void PickUpGun()
	{

		dataComps.EquipPickedUpWeapon (weaponIndex);
	}




	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("BlockMagnet")) {		// checks for the player Block magnet in order to be picked up.

			PickUpGun ();
			StartCoroutine (DestroyGun());
		}
	}

	IEnumerator DestroyGun()
	{
		// activate fading particles
		dataComps.playerSpeaker_ref.SfxToPlay=0;

		yield return new WaitForSeconds (0.1f);

		// destroy Game Obj
		Destroy (gameObject);


	}



}
