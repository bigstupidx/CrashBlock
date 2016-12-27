using UnityEngine;
using System.Collections;

public class WorldLimitsTrigger : MonoBehaviour {

	public BoxCollider col;

	public Color color;


	void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawCube (transform.position, col.size);
	}



}
