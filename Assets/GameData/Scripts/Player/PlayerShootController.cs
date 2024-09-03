using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private float shootingRange = 50f; 
    [SerializeField] private Transform gunTransform; 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float nextFireTime = 0f;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private AudioSource bulletShot;
    
    private void Start()
    {
       
    }

    void Update()
    {
        CheckClosestEnemyAndShoot();
    }

    private void CheckClosestEnemyAndShoot()
    {
        GameObject enemy = FindClosestEnemy();
        
        if (enemy != null && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        
    }
    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance && distanceToEnemy <= shootingRange)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    void Shoot()
    {
        bulletShot.Play();
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation,bulletParent);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = gunTransform.forward * bulletSpeed;
        }
        Destroy(bullet, 5f);
    }
}
