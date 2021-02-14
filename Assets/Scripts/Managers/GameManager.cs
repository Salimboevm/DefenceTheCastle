using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    bool gameOver = false;//is game over
    private void Awake()
    {
        //set instace and check for it 
        if(instance!=null && instance != this)
        {
            Destroy(instance.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance.gameObject);
    }
    private void Start()
    {
        AudioManager.instance.PlaySound("Map");//start playing bg music
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver)//check for game over
            return;//if it is, return from func

        if (PlayerStats.lives <= 0)//check for lives
        {
            EndGame();//if less than zero, call endgame
        }
    }
    /// <summary>
    /// func to control endgame
    /// </summary>
    void EndGame()
    {
        gameOver = true;//change value of gameover
        GameUI.instance.levelText.text = PlayerStats.playerLevel.ToString();//set level text
        GameUI.instance.gameOver.SetActive(true);//activate game over coin
    }
    /// <summary>
    /// func to load scene
    /// </summary>
    /// <param name="num"></param>
    public void SceneLoader(int num)
    {
        SceneManager.LoadScene(num);//load scene
    }
}
