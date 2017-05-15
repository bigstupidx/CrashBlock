using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public enum MissileType {CanonBall, FireBall };

public class ElementalMissile : MonoBehaviour {

	// this script handles the launch of the missile

	private FPSPlayer player_ref;
	private Transform player_Pos;
	[SerializeField]
	private float distanceChecker;
	[SerializeField]
	private float impactRange;
	private DataComps dataComps;

	public Transform startingPos;

	public GameObject core;
	[SerializeField]
	float lobHeight = 6;
	[SerializeField]
	float lobTime = .9f;

	// call this when launching
	public Vector3 targetPosition;

	[Header("This index is the element type of the missile")]
	public int elementIndex;

	[System.Serializable]
	public class ElementalMissileEffects
	{
		//totem type name
		[SerializeField]
		public string missileName;
		// totem type
		[SerializeField]
		public MissileType missileType;
		// missile objects
		[SerializeField]
		public MeshRenderer missileCore;
		public GameObject missileTrail;
		public GameObject missileImpact;		// activate to see effect
		public float damage;
		public AudioClip impactSound;

	};



	// make serialized class with name, totem element and missile prefab
	[Header("Shooting elemental missile  Variables")]
	public ElementalMissileEffects[] elementalMissileEffects;


	// receive player position and index
	public void StartMissile (Vector3 playerPos, Transform t, int index)
	{

		targetPosition = playerPos;
		elementIndex = index;
		startingPos = t;

		// activate mesh  elemental missile parent
		elementalMissileEffects [elementIndex].missileCore.gameObject.SetActive (true);

		StartCoroutine (Launch());

	}

	IEnumerator Launch()
	{
		yield return null;
		LaunchActivation ();
	}






	// called from the rigidbody that collides.
	public void MissileCollided(Transform impactPoint)
	{
        // load the correct audio mixer
       // AudioMixer mixer = dataComps.audioHandler_ref.mixer;
       // aSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Enemies")[0];

        // activate effects, disable core, play imp[act sound
        elementalMissileEffects [elementIndex].missileCore.enabled = false;
		elementalMissileEffects [elementIndex].missileImpact.SetActive (true);
		elementalMissileEffects [elementIndex].missileImpact.transform.position = impactPoint.position;
       // AudioSource.PlayClipAtPoint(elementalMissileEffects[elementIndex].impactSound, impactPoint.position, 1.0f);
        AudioSource gs = PlayAudioAtPos.PlayClipAt(elementalMissileEffects[elementIndex].impactSound, impactPoint.position, 1.0f);
        gs.spatialBlend = (0.8f);
        // gs.outputAudioMixerGroup = mixer.FindMatchingGroups("Enemies")[0];

        // calculate distance with player to inflict damage
        distanceChecker = Vector3.Distance (impactPoint.position, player_Pos.position);

		// if impact missile is whithin  impact range.
		if( distanceChecker <= impactRange)
		{
			// damage player
			player_ref.ApplyDamage(elementalMissileEffects[elementIndex].damage);
		}

		Destroy (gameObject, 3.0f);


	}


	void Awake()
	{
		dataComps = GameObject.FindGameObjectWithTag ("DataBase").GetComponent<DataComps> ();

		player_ref = dataComps.fpsPlayer_ref;
		player_Pos = player_ref.gameObject.transform;

       

    }


	// launch animation
	public void LaunchActivation()
	{
		iTween.MoveBy(core, iTween.Hash("y", lobHeight, "time", lobTime/2, "easeType", iTween.EaseType.easeOutQuad));
		iTween.MoveBy(core, iTween.Hash("y", -lobHeight, "time", lobTime/2, "delay", lobTime/2, "easeType", iTween.EaseType.easeInCubic));     
		iTween.MoveTo(gameObject, iTween.Hash("position", targetPosition, "time", lobTime, "easeType", iTween.EaseType.linear));
		//iTween.FadeTo(gameObject, iTween.Hash("delay", 3, "time", .5, "alpha", 0, "onComplete", "CleanUp"));
	}

}
