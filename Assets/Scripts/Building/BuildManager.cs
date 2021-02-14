using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Instance
    private static BuildManager _instance;

    public static BuildManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        //if (_instance != this)
        //    Destroy(this.gameObject);
        _instance = this;
    }
    #endregion

    private NodeUI nodeUI;//user interface for neodes
    private void Start()
    {
        nodeUI = FindObjectOfType<NodeUI>();//find nodeui
        selectedNode = null;//nothing selected
    }

    private TurretBluePrint turretToBuild;//turret to build 
    private Node selectedNode;//current selected node

    
    public bool CanBuild { get { return turretToBuild != null; } }//can we build on this node
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.Cost(); } }//do we have enough money

    /// <summary>
    /// func to setting turret to build 
    /// </summary>
    /// <param name="turret"></param>
    public void SetTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;//select turret 
        selectedNode = null;//deselect node

        nodeUI.Hide();//hide node ui
    }
    /// <summary>
    /// func to select node
    /// </summary>
    /// <param name="node"></param>
    public void SelectNode(Node node)
    {
        if (selectedNode == node)//check to selected node
        {
            //if it is current node deselect
            Deselect();
            return;
        }

        selectedNode = node;//selected node is node from the scene
        turretToBuild = null;//nothing to build

        nodeUI.SetTarget(node);//call set target func

    }
    /// <summary>
    /// func to get turret to build
    /// </summary>
    /// <returns></returns>
    public TurretBluePrint GetTurret()
    {
        return turretToBuild;
    }
    /// <summary>
    /// function to deselect node
    /// </summary>
    public void Deselect()
    {
        selectedNode = null;//deselect

        nodeUI.Hide();//hide ui
    }
}