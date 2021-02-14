using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
/// <summary>
/// bullet controlling script
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 70f;//speed of bullet
    [SerializeField]
    private float explRadius = 0;//exploiding radius 
    [SerializeField]
    private GameObject impactEffect;//particle affect for bullet 
    [SerializeField]
    private string name;//sound name 
    private Transform target;//target object
    [SerializeField]
    private int damage = 10;//damage amount
    /// <summary>
    /// function for searching 
    /// </summary>
    /// <param name="target"></param>
    public void Search(Transform target)
    {
        this.target = target;//find target
    }
    private void Update()
    {
        if(target == null)//check for target
        {
            //no target, destroy bullet
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;//direction to move
        float distanceThisFrame = speed * Time.deltaTime;//frame distance

        if (dir.magnitude <= distanceThisFrame)//check for magnitude
        {
            HitTarget();//call hit function
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);//move target 
        transform.LookAt(target);//look to target
    }
    /// <summary>
    /// function for hitting and damaging target
    /// </summary>
    void HitTarget()
    {
        GameObject go = Instantiate(impactEffect, transform.position, transform.rotation);//instantiate particle effect

        Destroy(go, 2f);//destroy particles

        if(explRadius > 0f)//check for exploiding radius
        {
            //if it is bigger than 0
            Explode();//call for explode function
        }
        else
        {
            //if not 
            Damage(target);//call for damaging function
        }
        Destroy(gameObject);//destroy bullet
    }
    /// <summary>
    /// function for exploiding bullets
    /// </summary>
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explRadius);//get colliders in exploiding radius
        foreach (Collider collider in colliders)//serach for them
        {
            if(collider.CompareTag("Enemy"))//search for enemy
            {
                Damage(collider.transform);//explode and damage enemies
            }
        }
    }
    /// <summary>
    /// function for damaging enemies
    /// </summary>
    /// <param name="enemy"></param>
    void Damage(Transform enemy)
    {
        Enemy tmp = enemy.GetComponent<Enemy>();//temp enemy

        if (tmp != null)//check for temp enemy
        {
            tmp.TakeDamage(damage);//if there is, call take damage func
        } 
    }
    /// <summary>
    /// draw gizmos to see on ispector
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explRadius);//call sphere gizmos, to see exploiding radius
        Gizmos.color = Color.red;//give color
    }
    ///get name 
    public string Name()
    {
        return name;
    }
}

