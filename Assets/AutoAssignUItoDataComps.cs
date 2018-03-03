using UnityEngine;
using System.Collections.Generic;

public class AutoAssignUItoDataComps : MonoBehaviour {


    private DataComps dataComps;
    [SerializeField]
    private List<GameObject> uiToAssign = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        dataComps = GameObject.FindGameObjectWithTag("DataBase").GetComponent<DataComps>();
        AssignUIGameObjectList();
    }
	

    private void AssignUIGameObjectList()
    {
        for (int i=0; i< uiToAssign.Count; i++)
        {
            dataComps.uiImages.Add(uiToAssign[i]);
        }
    }


}
