using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] Image hpBar;

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
}
