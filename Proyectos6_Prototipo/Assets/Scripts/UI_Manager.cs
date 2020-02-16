using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] Image hpBar;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI medkitText;

    GameObject player;

    static UI_Manager instance;

    public static UI_Manager Instance { get => instance; }

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void setHP()
    {
        hpBar.fillAmount = player.GetComponent<Life_Base>().getHP();
    }

    public void setAmo(float ammo)
    {
        ammoText.text = ammo + " bullets";
    }

    public void setCurrentObject(InventoryItem go)
    {
        medkitText.text = go.name + ": " + go.uses;
    }
}
