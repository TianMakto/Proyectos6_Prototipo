using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    float heal = 30;
    float clips;
    float medkits;

    public void TakeAClip()
    {
        clips++;
    }

    public void TakeAMedkit()
    {
        medkits++;
    }

    public void UseClip()
    {
        if(clips > 0)
        {
            transform.Find("Weapon").GetComponent<Weapon>().Recharge();
            clips--;
        }
    }

    public void UseMedKit()
    {
        if(medkits > 0)
        {
            GetComponent<Life_Base>().Heal(heal);
            medkits--;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UseClip();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            UseMedKit();
        }
    }
}
