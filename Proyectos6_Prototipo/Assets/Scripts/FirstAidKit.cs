using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.Find("Inventory").GetComponent<Inventory>().TakeAMedkit();
            Destroy(this.gameObject);
        }
    }
}
