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

    static UI_Manager instance;

    public static UI_Manager Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    public void setHP(float currentHp, float maxHp)
    {
        hpBar.fillAmount = currentHp / maxHp;
    }

    public void setAmo(float ammo, float clips)
    {
        ammoText.text = ammo + " / " + clips;
    }

    public void setMedkit(float medkits)
    {
        medkitText.text = "Medkits: " + medkits;
    }
}
