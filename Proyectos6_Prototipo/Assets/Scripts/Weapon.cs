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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
            ammo--;
        }
    }

}
