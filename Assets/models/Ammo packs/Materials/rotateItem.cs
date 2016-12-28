using UnityEngine;
using System.Collections;

public class rotateItem : MonoBehaviour {

	public float rotx = 50;
	public float roty = 50;
	public float rotz = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(Time.deltaTime* rotx,Time.deltaTime*roty,Time.deltaTime*rotz));
	
	}
}
