using UnityEngine;
using System.Collections;

public class ChopperBlades : MonoBehaviour {



	[SerializeField]
	private Transform topblades_T;
	[SerializeField]
	private Transform tailBlades_T;
	[SerializeField]
	private float rotation_Speed;

	
	// Update is called once per frame
	void Update () 
	{


		topblades_T.Rotate (0, rotation_Speed* Time.deltaTime, 0);
		tailBlades_T.Rotate (rotation_Speed* Time.deltaTime, 0,0);

	
	}
}
