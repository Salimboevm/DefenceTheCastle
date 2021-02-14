using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;//how much money we have
    public int startMoney = 100;//starting money

    public static int lives;//lives of player
    public int startLives;//starting lives

    public static int playerLevel;//level of player
    private void Start()
    {
        startLives = 5;//start lives are 5
        money = startMoney;//money is equal to start moeny
        lives = startLives;//lives is equal to start lives

        playerLevel = 0;//player level is zero
    }
    /// <summary>
    /// func to get lives from other scripts
    /// </summary>
    /// <returns></returns>
    public static int LivesReturn()
    {
        return lives = 5;
    }
}
