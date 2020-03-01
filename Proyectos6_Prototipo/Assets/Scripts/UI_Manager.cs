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
    [SerializeField] GameObject itemUnlockedPanel;

    GameObject player;
    bool timeStopped;
    static UI_Manager instance;

    public static UI_Manager Instance { get => instance; }

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        itemUnlockedPanel.SetActive(false);
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
        medkitText.text = go.name + ": " + go.uses;
    }

    public void itemUnlocked(string itemName)
    {
        itemUnlockedPanel.SetActive(true);
        itemUnlockedPanel.transform.Find("itemName").GetComponent<TextMeshProUGUI>().text = itemName;
        Time.timeScale = 0;
        timeStopped = true;
    }

    private void Update()
    {
        if(timeStopped && Input.anyKeyDown)
        {
            itemUnlockedPanel.SetActive(false);
            timeStopped = false;
            Time.timeScale = 1;
        }
    }
}
