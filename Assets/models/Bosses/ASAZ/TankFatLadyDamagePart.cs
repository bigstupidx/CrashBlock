using UnityEngine;
using System.Collections;

public class TankFatLadyDamagePart : MonoBehaviour
{
    [Range(0, 100), SerializeField]
    private float damageReduction;
    private float dam;

    [SerializeField]
    private TankFatLady tankfatLady;

    [SerializeField]
    private bool isFatLadybody;
    [Range(0, 100), SerializeField]
    private float damageAmplification;


    public void ReceiveDamage(float damage)        //---- tells the boos to receive damage
    {
        

        if (isFatLadybody)
        {
            print("Woman damaged ");
            dam = damage + (damage * (damageAmplification * 0.01f));
            if (tankfatLady)
                tankfatLady.TakeDamage(dam, true);
        }else
        {
            dam = damage - (damage * (damageReduction * 0.01f));
            if(tankfatLady)
            tankfatLady.TakeDamage(dam, false);

        }
    }
}