using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAim : MonoBehaviour
{
    [SerializeField] SpriteRenderer weaponSprite;
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject Knife;

    private void Start()
    {
        Weapon.SetActive(true);
        Knife.SetActive(false);
    }

    void Update()
    {
        if (!transform.parent.GetComponent<Life_Base>().dead)
        {
            this.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            //print("ESTOY APUNTANDDOOOOO");
        }
        //transform.eulerAngles = new Vector3(0, 180, transform.eulerAngles.z + 180);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Weapon.SetActive(!Weapon.activeSelf);
            Knife.SetActive(!Knife.activeSelf);
        }
    }
}
