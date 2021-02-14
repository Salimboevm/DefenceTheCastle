using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;//speed of enemy

    private Transform target;//target waypoint
    private int wavepointIndex = 0;//wave point index num
    [SerializeField]
    private int health = 100;//health of enemy
    private void Start()
    {
        target = Waypoints.waypoints[0];//get target
    }
    /// <summary>
    /// take damage from enemy
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        health -= amount;//deduct health by amount

        if (health <= 0)//checckc for health
        {
            Die();//if less or equalt to zero die
        }
    }
    /// <summary>
    /// func to die
    /// </summary>
    void Die()
    {
        PlayerStats.money+= Random.Range(1,5);//add to money
        WaveSpawner.alives--;//deduct lives
        Destroy(gameObject);//destroy gameobject
    }
    private void Update()
    {
        Vector3 direction = target.position - transform.position;//get direction
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);//move game object

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)//check distance
        {
            GetNextWaypoint();//call func to get next waypoint
        }
    }
    /// <summary>
    /// func to getting next waypoint
    /// </summary>
    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length - 1)//check for waypoints
        {
            EndPath();//if it is end of the path, call for endpaht
            return;//return from func
        }

        wavepointIndex++;//else increase wave point index
        target = Waypoints.waypoints[wavepointIndex];//get next waypoint
    }
    /// <summary>
    /// func to end path
    /// </summary>
    void EndPath()
    {
        PlayerStats.lives--;//deduct player live
        WaveSpawner.alives--;//deduct alive enemies
        Destroy(gameObject);//destroy go
    }
}
