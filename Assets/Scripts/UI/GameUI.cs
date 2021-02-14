using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : UIManager
{
    #region
    public static GameUI instance;

    private void Awake()
    {
        if(instance != null &&instance!= this)
        {
            Destroy(instance.gameObject);
            return;
        }
        instance = this;
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        MoneyChange();//call func of money change
        LivesUI();//call lives ui func

    }
    /// <summary>
    /// func to set money changes
    /// </summary>
    public void MoneyChange()
    {
        money.text = PlayerStats.money.ToString();//set money text to current money amount
    }
    /// <summary>
    /// func to set lives text
    /// </summary>
    public void LivesUI()
    {
        lives.text = PlayerStats.lives.ToString();//set lives text to current lives amount
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//check for input
        {//if esc pressed 
            PauseManager();//pause game
        }
        LivesUI();//ipdate lives text
        MoneyChange();//update money text
    }

    /// <summary>
    /// func to load scene
    /// </summary>
    /// <param name="num"></param>
    public void ButtonActions(int num)
    {
        GameManager.instance.SceneLoader(num);//load scene
    }
    /// <summary>
    /// func to manage pause
    /// </summary>
    public void PauseManager()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);//activate/deactivate pause panel

        if (pausePanel.activeSelf)//check for panel
        {
            //if it is active 
            Time.timeScale = 0;//stop game
        }
        else
        {
            //if not 
            Time.timeScale = 1;//continue game
        }
    }
    /// <summary>
    /// func to retry game call from ui
    /// </summary>
    public void Retry()
    {
        Time.timeScale = 1;//continue game
        gameOver.SetActive(false);//deactivate game over panel
        PlayerStats.LivesReturn();//get lives
        GameManager.instance.SceneLoader(1);//load current scene
    }
    /// <summary>
    /// func to go back to menu, call from ui
    /// </summary>
    public void Menu()
    {
        Time.timeScale = 1;//continue
        gameOver.SetActive(false);//deactivate panel
        PlayerStats.LivesReturn();//set lives
        GameManager.instance.SceneLoader(0);//go back to main menu
    }
}
