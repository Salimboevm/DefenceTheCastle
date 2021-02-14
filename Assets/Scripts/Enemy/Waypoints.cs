using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;//waypoints

    private void Awake()
    {
        waypoints = new Transform[transform.childCount];//get num of waypoints

        for (int i = 0; i < waypoints.Length; i++)//loop through waypoints
        {
            waypoints[i] =  transform.GetChild(i);//set waypoints
        }
    }


}
