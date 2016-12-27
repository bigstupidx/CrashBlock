using UnityEngine;
using System.Collections;

public class MenuObject : MonoBehaviour {

	[SerializeField]
	private int ObjectSpeed;

	void Update () 
	{

		transform.Translate (Vector3.forward * Time.deltaTime * ObjectSpeed, Space.World);

	}
}
