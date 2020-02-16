using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage = 20;
    [SerializeField] float clipSize = 8;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootingPoint;
    float ammo;
    private void Start()
    {
        ammo = clipSize;
        UI_Manager.Instance.setAmo(ammo);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0 && !transform.parent.transform.parent.GetComponent<Life_Base>().dead)
        {
            GameObject newBullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
            newBullet.GetComponent<Bullet>().damage = damage;
            ammo--;
            UI_Manager.Instance.setAmo(ammo);
        }
    }

    public void Recharge()
    {
        ammo = clipSize;
    }

    public float GetAmmo()
    {
        return ammo;
    }
}
