using UnityEngine;
using System.Collections;

public class NPCAnim : MonoBehaviour {


	[SerializeField]
	private Animator npcAnimator;
	[SerializeField]
	private SkinnedMeshRenderer skinmesh;

	[SerializeField]
	private Material blockTransparent;	// this has to substitute the basic material
	[SerializeField]
	private Material blockFader;		// this is assigned to the second material, that has to be a fader.
	[SerializeField]
	private Texture blockFader_texture;	// the enemy normal texture



	void Start ()
	{
		npcAnimator.enabled = false;
	}


	public void AnimationKillCaller(DamagedBodyPart bpart)
	{
		StopAllCoroutines ();
		npcAnimator.enabled = true;
		Material[] mats = new Material[]{blockTransparent, blockFader };
		skinmesh.materials = mats;//materials[0] = blockTransparent;		// make the interior transparent
		//skinmesh.sharedMaterials[0] = blockTransparent;
		//blockFader.SetTexture = blockFader_texture;

		switch (bpart) 
		{

			case DamagedBodyPart.Head:
			StartCoroutine (ActivateTrigger ("killHead"));
			break;
		
			case  DamagedBodyPart.Chest:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;

			case  DamagedBodyPart.LowerLegL:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;
			case  DamagedBodyPart.UpperLegL:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;

			case  DamagedBodyPart.LowerLegR:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;
			case  DamagedBodyPart.UpperLegR:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;
			case  DamagedBodyPart.LowerArmL:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;
			case  DamagedBodyPart.UpperArmL:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;

			case  DamagedBodyPart.LowerArmR:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;
			case  DamagedBodyPart.UpperArmR:
			StartCoroutine (ActivateTrigger ("killHead"));	// call one if none found
			break;


		}

	}

	IEnumerator ActivateTrigger(string trig)
	{
		yield return new WaitForSeconds (0.01f);
		npcAnimator.SetTrigger (trig);

	}


	public void AnimationHurtCaller (DamagedBodyPart bpart)		//-- call the animator for hurt
	{
		npcAnimator.enabled = true;

		print ("Hurt animation");

		//switch (bpart) {
		//
		//	case DamagedBodyPart.Chest:
		//
		//	print ("Called chest trigger");
		//	StartCoroutine (ActivateHurtTrigger ("hurtChest"));
		//	break;
		//
		//	StartCoroutine (ActivateHurtTrigger ("hurtChest"));	// call one if none found
		//
		//}
		StartCoroutine (ActivateHurtTrigger ("hurtChest"));	// call one if none found
	}

	IEnumerator ActivateHurtTrigger(string trig)
	{
		yield return new WaitForSeconds (0.01f);
		npcAnimator.SetTrigger (trig);

		yield return new WaitForSeconds (0.80f);
		npcAnimator.enabled = false;
	}


}
