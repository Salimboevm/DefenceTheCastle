using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    [SerializeField]
    private GameObject prefab;//turret game object
    [SerializeField]
    private int cost;//cost of turret
    [SerializeField]
    private GameObject upgradedPrefab;//upgrading gameobject
    [SerializeField]
    private int upgradeCost;//cost of upgrade
    /// <summary>
    /// function to get selling cost
    /// </summary>
    /// <returns></returns>
    public int GetAmount()
    {
        return cost / 2;
    }
    /// <summary>
    /// func to get cost
    /// </summary>
    /// <returns></returns>
     public int Cost() {
        return cost;
    }/// <summary>
    /// func to get upgrade cost
    /// </summary>
    /// <returns></returns>
    public int UpgradeCost()
    {
        return upgradeCost;
    }
    /// <summary>
    /// func to get turret prefab
    /// </summary>
    /// <returns></returns>
    public GameObject Prefab()
    {
        return prefab;
    }
    /// <summary>
    /// func to get upgrade turret
    /// </summary>
    /// <returns></returns>
    public GameObject UPrefab()
    {
        return upgradedPrefab;
    }
}
