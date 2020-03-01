using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    [SerializeField] Color colorOff;
    [SerializeField] int index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Skills_and_Tools>())
        {
            if(index == 1)
            {
                collision.GetComponent<Skills_and_Tools>().CatchDJ();
                print("Tengo doble Salto");
                UI_Manager.Instance.itemUnlocked("Double Jump");
                TurnOff();
            }
            if (index == 2)
            {
                collision.GetComponent<Skills_and_Tools>().CatchHook();
                print("Tengo Gancho");
                UI_Manager.Instance.itemUnlocked("Hook");
                TurnOff();
            }            
        }
    }

    void TurnOff()
    {
        GetComponent<SpriteRenderer>().color = colorOff;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
