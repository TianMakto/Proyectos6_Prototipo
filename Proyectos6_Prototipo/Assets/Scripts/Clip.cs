using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
            //print("VAMOOOOS");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Inventory>().TakeAClip();
            Destroy(this.gameObject);
        }
    }

}
