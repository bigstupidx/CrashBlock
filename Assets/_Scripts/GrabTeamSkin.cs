using UnityEngine;
using System.Collections;

public class GrabTeamSkin : MonoBehaviour {

   

    private TeamSkin teamSkin_ref;
    private MeshRenderer mesh;

    private Material currentMat;
    private Renderer rend;

    void OnEnable()
    {
        if (!teamSkin_ref)
            teamSkin_ref = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TeamSkin>();

        if (!mesh)
            mesh = gameObject.GetComponent<MeshRenderer>();

        rend = gameObject.GetComponent<Renderer>();

        rend.material.SetTexture(("_MainTex"),teamSkin_ref.currentSkin);

       // mesh.materials[0] = teamSkin_ref.currentSkin;

        

    }
}
