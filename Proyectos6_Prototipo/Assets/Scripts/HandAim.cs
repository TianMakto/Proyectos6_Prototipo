using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAim : MonoBehaviour
{
    [SerializeField] SpriteRenderer weaponSprite;

    void Update()
    {
        if (!transform.parent.GetComponent<Life_Base>().dead)
        {
            this.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            //print("ESTOY APUNTANDDOOOOO");
        }
        //transform.eulerAngles = new Vector3(0, 180, transform.eulerAngles.z + 180);
    }
}
