using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField]
    private Color hooverColor;//hover color for feedback
    private Color startColor;//starting color of node
    private Renderer rend;//renderer
    
    [Header("Building")]
    public Vector3 positionOffset;//offset position 
    [SerializeField]
    private GameObject buildEffect;//particle effect

    [Header("Do not fill")]
    private GameObject turret;//turret to build
    [HideInInspector]
    public TurretBluePrint bluePrint;//turret blueprint
    [HideInInspector]
    public bool upgraded = false;//is upgraded
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (!BuildManager.Instance.CanBuild)//check for we can build on this node
            return;//if not return

        if (BuildManager.Instance.HasMoney)//check for we have money to build
        {
            rend.material.color = hooverColor;//change color
        }
        else
        {
            rend.material.color = Color.red;//if not change color to red
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;//set color to starting color
    }
    private void OnMouseDown()
    {
        if(turret != null)//check for turret
        {
            BuildManager.Instance.SelectNode(this);//if we have turret, build it 
            return;
        }

        if (!BuildManager.Instance.CanBuild)//check for we can build on this node
            return;

        BuildTurret(BuildManager.Instance.GetTurret());//get building turret
    }
    /// <summary>
    /// func to build turret
    /// </summary>
    /// <param name="bluePrint"></param>
    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.money < bluePrint.Cost())//check we have enough money
        {
            Debug.LogWarning("Not enough money");//print on console
            return;
        }
        PlayerStats.money -= bluePrint.Cost();//money deducted by cost
        GameObject turret = (GameObject)Instantiate(bluePrint.Prefab(), GetBuildPos(), Quaternion.identity);//build turret
        this.turret = turret;//set turret
        this.bluePrint = bluePrint;//set blueprint
        GameObject effect = Instantiate(buildEffect, GetBuildPos(), Quaternion.identity);//instantiate effect
        Destroy(effect, 5f);//destroy affect
    }
    /// <summary>
    /// func to upgrade turret
    /// </summary>
    public void UpgradeTurret()
    {
        if (PlayerStats.money < bluePrint.UpgradeCost())//check for money
        {
            Debug.LogWarning("Not enough money");
            return;
        }
        PlayerStats.money -= bluePrint.UpgradeCost();//money deducted by upgrade cost
        Destroy(this.turret);//destroy current turret
        GameObject turret = (GameObject)Instantiate(bluePrint.UPrefab(), GetBuildPos(), Quaternion.identity);//build upgraded turret
        this.turret = turret;//set new turret
        upgraded = true;//change upgraded value
        GameObject effect = Instantiate(buildEffect, GetBuildPos(), Quaternion.identity);//affects
        Destroy(effect, 5f);//destroy affects
    }
    /// <summary>
    /// func to sell turret
    /// </summary>
    public void SellTurret()
    {
        PlayerStats.money += bluePrint.GetAmount();//add to money 

        Destroy(turret);//destroy current turret
        bluePrint = null;//delete blueprint
    }
    
    /// <summary>
    /// func to get position of build
    /// </summary>
    /// <returns></returns>
    public Vector3 GetBuildPos()
    {
        return transform.position + positionOffset; 
    }
}
