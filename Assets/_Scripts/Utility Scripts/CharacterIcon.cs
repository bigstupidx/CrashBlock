using UnityEngine;
using System.Collections;

public enum CharacterIconType{Player, Enemy, Ally};

public class CharacterIcon : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRend;
    [SerializeField]
    private Material playerMat;
    [SerializeField]
    private Material allyMat;
    [SerializeField]
    private Material enemyMat;



    public void SetMaterial(CharacterIconType chIcon)
    {
        if(meshRend == null && gameObject.GetComponent<MeshRenderer>())
        {
            meshRend = gameObject.GetComponent<MeshRenderer>();
        }

        if(meshRend == null)
        {
            return;
        }


        switch (chIcon)
        {
            case CharacterIconType.Player:
                meshRend.material = playerMat;
                break;
            case CharacterIconType.Enemy:
                meshRend.material = enemyMat;
                break;
            case CharacterIconType.Ally:
                meshRend.material = allyMat;
                break;


        }
    }

	
}
