using UnityEngine;
using System.Collections;
using EasyEditor;


public enum CustomEnemyEnum { Normal, Boss, Epic  }


public class CustomEnemyDamage : MonoBehaviour {


	// this script communicates damage upwards to any custom enemy we want.

	public CustomEnemyEnum enemyType;

	private Transform player_T;

	[Header("Enemy AI components by type"), SerializeField]
	private CharacterDamage character_ref;

	[Header("Flashing damage")]
	private Color32 startingColor = new Color32 (0, 0, 0, 0);
	[SerializeField]
	private Color32 damageColor;
	[Tooltip("How fast will the flashing be"),SerializeField]
	private float flashingTime = 0.5f;
	private bool isFlashing;
	public MeshRenderer mesh;
	private Color lerpedColor;

	[Header("Damage Amplification or reduction depending on hit part")]
	[Tooltip("This number will multiply the damage")]
	[Range(0.1f, 8.0f),SerializeField]
	private float damageAug = 1.0f;

	[Header("Check if this part can be destroyed"),SerializeField]
	private bool isDestructible;

	[SerializeField]
	private float destructiblePartHp;

	private  float DestructiblePartHp
	{
		get{ return destructiblePartHp; }
		set
		{ 
		
			destructiblePartHp = value;

			if (destructiblePartHp <= 0.0f) 
			{
				DestroyPart ();
			}

		}
	}


	[SerializeField]
	private GameObject destroyParticles;
	[SerializeField]
	private AudioClip destroySfx; 


	GameObject g;


	public void ApplyDamage(float damage, Vector3 vec1, Vector3 vec2, Transform t, bool boolOne, bool boolTwo)
	{

		float newDmg = damage * damageAug;
		print ("Body amror damage is "+ newDmg);
		ColorFlash ();


		switch (enemyType)
		{

			case CustomEnemyEnum.Normal:
				if(character_ref)
				character_ref.ApplyDamage( newDmg, vec1, vec2, t , true, false);

			break;

		}


		// substract hp from part if is destructible
		if( isDestructible)
		{
			DestructiblePartHp -= damage * damageAug;
		}


	}






	// destroys the part and if available it instantiates particles and emits a sound
	public void DestroyPart()
	{

		DataComps datacomps = GameObject.FindGameObjectWithTag ("DataBase").GetComponent<DataComps>();

		if (destroyParticles != null) 
		{
			if (destroySfx!= null) 
			{
					
					g = Instantiate (destroyParticles, gameObject.transform.position, Quaternion.identity)as GameObject;

					Destroy (g, 5.0f);

						if (g.GetComponent<AudioSource> () && destroySfx) 
						{
							g.GetComponent<AudioSource> ().PlayOneShot (destroySfx, datacomps.sfxVolume);
						}

					Destroy (gameObject);

				return;

			} else {

			
				g = Instantiate (destroyParticles, gameObject.transform.position, Quaternion.identity)as GameObject;
				Destroy (g, 5.0f);
				Destroy (gameObject);
			}

			Destroy (gameObject);


		}

		Destroy (gameObject);
		
	}


	[Inspector]
	public void ColorFlash()
	{

		if (mesh == null) 
		{
			mesh = gameObject.GetComponent<MeshRenderer> ();
			startingColor = mesh.material.GetColor ("_EmissionColor");
			lerpedColor = startingColor;
		}

		isFlashing = true;
		StartCoroutine ( FlashingRedCo());

	}


	IEnumerator FlashingRedCo()
	{

		float elapsedTime = 0.0f;

		while (elapsedTime < flashingTime) 
		{
			elapsedTime += Time.deltaTime;

			lerpedColor = Color32.Lerp (startingColor, damageColor, (elapsedTime / (flashingTime/2)));

			mesh.material.SetColor ("_EmissionColor", lerpedColor);
			yield return null;
		}


		elapsedTime = 0.0f;

		while (elapsedTime < flashingTime) 
		{
			elapsedTime += Time.deltaTime;

			lerpedColor = Color32.Lerp (damageColor, startingColor, (elapsedTime / (flashingTime/2)));

			mesh.material.SetColor ("_EmissionColor", lerpedColor);
			yield return null;
		}


		//yield return new WaitForSeconds (0.01f);
		//
		//lerpedColor = Color.Lerp (startingColor, damageColor, Mathf.PingPong (Time.deltaTime, 1));
		//
		//
		//mesh.material.SetColor ("_Color", lerpedColor);
		//
		//
		//
		//if (isFlashing) 
		//{
		//	StartCoroutine ( FlashingRedCo());
		//}
		//
		//yield return null;

	}


}
