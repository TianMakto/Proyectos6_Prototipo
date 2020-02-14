using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    float heal = 30;
    float clips;
    float medkits;

    [SerializeField] List<GameObject> inventory = new List<GameObject>();
    GameObject currentGO;

    private void Start()
    {
        UI_Manager.Instance.setAmo(transform.Find("Hand/Weapon").GetComponent<Weapon>().GetAmmo(), clips);
        UI_Manager.Instance.setMedkit(medkits);
    }

    public void TakeAClip()
    {
        clips++;
        UI_Manager.Instance.setAmo(transform.Find("Hand/Weapon").GetComponent<Weapon>().GetAmmo(), clips);
    }

    public void TakeAMedkit()
    {
        medkits++;
        UI_Manager.Instance.setMedkit(medkits);
    }

    public void UseClip()
    {
        if(clips > 0)
        {
            transform.Find("Hand/Weapon").GetComponent<Weapon>().Recharge();
            clips--;
            UI_Manager.Instance.setAmo(transform.Find("Hand/Weapon").GetComponent<Weapon>().GetAmmo(), clips);
        }
    }

    public void UseMedKit()
    {
        if(medkits > 0)
        {
            GetComponent<Life_Base>().Heal(heal);
            medkits--;
            UI_Manager.Instance.setMedkit(medkits);
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    UseClip();
        //}

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    UseMedKit();
        //}
    }

    public float GetClips()
    {
        return clips;
    }
}
