using UnityEngine;
using System.Collections;

public class VechiclesPassingFinish : MonoBehaviour {


    [SerializeField]
    private VehiclesPassing vp;



    private void OnTriggerEnter(Collider collision)
    {

        if (vp.vehOneName == collision.gameObject.name)
        {
            vp.vehicleOne.position = vp.startPos.position;
        }
        if (vp.vehTwoName == collision.gameObject.name)
        {
            vp.vehicleTwo.position = vp.startPos.position;
        }
    }

}
