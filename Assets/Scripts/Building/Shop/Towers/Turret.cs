using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private float range = 15;//fire range
    [SerializeField]
    private float turnSpeed = 5f;//fire turn speed
    [SerializeField]
    private float fireRate = 1f;//fire rate speed
    private float fireCountdown = 0;//fire countdown to make next fire

    [Header("Setup Fields")]
    [SerializeField]
    private string name = "";//turret name
    [SerializeField]
    private Transform rotatingPart;//gameobject to rotate
    private Transform target;//target game object
    [SerializeField]
    private GameObject bulletPrefab;//bullet prefab to instantiate
    [SerializeField]
    private Transform firePoint;//fire point to instantiate parent

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);//repeatedly update target in every 5sec
    }
    /// <summary>
    /// return turret name
    /// </summary>
    /// <returns></returns>
    public string Name()
    {
        return name;
    }
    /// <summary>
    /// function to update target
    /// </summary>
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(name);//find enemies

        float shortestDistance = Mathf.Infinity;//take shortest distance
        GameObject nearestEnemy = null;//create and find closest enemy

        foreach (GameObject enemy in enemies)//search for enemy
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);//get enemy distance from turret

            if (distanceToEnemy < shortestDistance)//check is it shortes
            {
                //if yes take this enemy as a closest one
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)//do we have closest enemy in firing range
        {
            target = nearestEnemy.transform;//we found target enemy
        }
        else
        {
            target = null;//we could not find target enemy
        }
    }
    private void Update()
    {
        if (target == null)//check for target enemy
        {
            return;
        }

        Vector3 dir = target.position - transform.position;//direction 
        Quaternion lookRot = Quaternion.LookRotation(-dir);//rotation
        Vector3 rotate = Quaternion.Lerp(rotatingPart.rotation, lookRot, Time.deltaTime * turnSpeed).eulerAngles;//rotate our rotation part to enemy

        rotatingPart.rotation = Quaternion.Euler(0, rotate.y, 0);//rotate

        if (fireCountdown <= 0)//check for countdown
        {
            Shoot();//shoot to enemy
            fireCountdown = 1f / fireRate;//calculate countdown
        }
        fireCountdown -= Time.deltaTime;//calculate countdown
    }
    /// <summary>
    /// function to shoot to enemy
    /// </summary>
    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//instantiate bullet game object
        Bullet bullet = bulletGO.GetComponent<Bullet>();//get bullet script  to instantiated object
        AudioManager.instance.PlaySound(bullet.Name()); //play bullet sound
        if (bullet != null)//check for bullet
            bullet.Search(target);//if there is, search for target
    }
    /// <summary>
    /// draw gizmos to see range
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;//make color for gizmos
        Gizmos.DrawWireSphere(transform.position, range);//draw sphere gizmos
    }
}
