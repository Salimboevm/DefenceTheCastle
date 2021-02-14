using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : UIManager
{
    private Node target;//target node

    [SerializeField]
    private GameObject ui;//canvas object of upgrade and selling

    private void Start()
    {
        ui.SetActive(false);//deactivate ui
    }
    /// <summary>
    /// func to set target node
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(Node target)
    {
        this.target = target;//set target node

        gameObject.transform.position = this.target.GetBuildPos();//set position of gameobject

        if (target.upgraded)//check gameobject is not upgraded 
        {
            uCost.text = "Max";//if it is, change text to max
            upgrade.interactable = false;//change button to not pressable
        }
        sCost.text = "$" + target.bluePrint.GetAmount();//change cost
        ui.SetActive(true);//activate canvas
    }
    /// <summary>
    /// func to hide canvas,call from ui
    /// </summary>
    public void Hide()
    {
        ui.SetActive(false);//hide canvas
    }
    /// <summary>
    /// func to upgrade turret,call from ui
    /// </summary>
    public void UpgradeTurret()
    {
        target.UpgradeTurret();//upgrade target turret

        BuildManager.Instance.Deselect();//deselect
    }
    /// <summary>
    /// func to sell turret, call from ui
    /// </summary>
    public void SellTurret()
    {
        target.SellTurret();//call selling func 
        BuildManager.Instance.Deselect();//deselect
        target.upgraded = false;//turret is not upgraded
    }
}
