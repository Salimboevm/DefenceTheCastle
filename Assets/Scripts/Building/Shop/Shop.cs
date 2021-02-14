using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standard;//standard turret to build
    public TurretBluePrint missile;//missile turret to build
    /// <summary>
    /// func to build standard turret
    /// </summary>
    public void StandardShop()
    {
        BuildManager.Instance.SetTurretToBuild(standard);
    }
    /// <summary>
    /// func to build missile turret
    /// </summary>
    public void MissileShop()
    {
        BuildManager.Instance.SetTurretToBuild(missile);
    }
    
}
