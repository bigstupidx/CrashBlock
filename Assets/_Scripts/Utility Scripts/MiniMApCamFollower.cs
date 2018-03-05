using UnityEngine;
using System.Collections;

public class MiniMApCamFollower : MonoBehaviour {


#region Members
    public LayerMask miniMapLayerMask;
    //cache members
    private Transform player_T;
    private DataComps dataComps;
    private Vector3 newPos;
#endregion

    // Use this for initialization
    void Start ()
    {
        dataComps = ServiceLocator.dataComps;
        player_T = dataComps.fpsPlayer_ref.transform;
    }
	
	// follow player around
	void LateUpdate ()
    {
        newPos = player_T.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, player_T.eulerAngles.y, 0f);
    }
}
