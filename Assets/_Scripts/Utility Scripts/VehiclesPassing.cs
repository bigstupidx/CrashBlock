using UnityEngine;
using System.Collections;

public class VehiclesPassing : MonoBehaviour {

    // This script makes any vehicle move from point a, to point b
    // it can instantiate a pursuing vehicle that will folow the same path.
    // the translating vehicle will have Look at target, so it will bend acordingly


    [SerializeField]
    private float vehicleSpeed;

    // vehicles transforms

    public Transform vehicleOne, vehicleTwo;

    [SerializeField]
    public Transform startPos, finishPos;
    [HideInInspector]
    public string vehOneName, vehTwoName;

    [SerializeField]
    private bool isvehicleChasing;
    [SerializeField]
    private float timeForChaser;


    private void Start()
    {
        vehicleOne.gameObject.SetActive(true);
        vehicleOne.position = startPos.position;
        vehicleTwo.gameObject.SetActive(false);

        vehOneName = vehicleOne.name;
        vehTwoName = vehicleTwo.name;
    }



    // Update is called once per frame
    void Update ()
    {
        #region spawn timer for chaser vehicle
        if(isvehicleChasing && timeForChaser > 0)
        {
            timeForChaser -= Time.deltaTime;
        }

        if (isvehicleChasing && timeForChaser <= 0)
        {
            isvehicleChasing = false;
            vehicleTwo.gameObject.SetActive(true);
            vehicleTwo.position = startPos.position;
        }
        #endregion


        #region check vehicle one for its destination
        if(vehicleOne.transform.position != finishPos.position)
        {

           vehicleOne.LookAt(finishPos);
            vehicleOne.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed);
        }


        #endregion

        #region check vehicle two for its destination
        if (vehicleTwo.gameObject.activeSelf && vehicleTwo.transform.position != finishPos.position)
        {
            vehicleTwo.LookAt(finishPos);
            vehicleTwo.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed);

        }


        #endregion


    }






}
