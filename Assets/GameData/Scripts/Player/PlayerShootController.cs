using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nextFireTime = 0f;
    [SerializeField] private Transform bulletParent;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,gunPoint.position, gunPoint.rotation,bulletParent);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = gunPoint.forward * bulletSpeed;
        Destroy(bullet, 5f);
    }
}
