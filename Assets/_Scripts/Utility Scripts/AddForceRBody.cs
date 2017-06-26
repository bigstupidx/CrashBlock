using UnityEngine;
using System.Collections;

public class AddForceRBody : MonoBehaviour {

	public float thrustback;
	public float thrustup;
	public Rigidbody rb;

	public bool shouldIthrow = true;

	void OnEnable() 
	{
		rb = gameObject.GetComponent<Rigidbody>();
	}


	void FixedUpdate ()
	{
		if (shouldIthrow == true) { 
			rb.AddForce (Camera.main.transform.forward * thrustback + Camera.main.transform.up * thrustup);
			shouldIthrow = false; 
		}
	}
}
