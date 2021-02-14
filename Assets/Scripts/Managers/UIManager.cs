using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager: MonoBehaviour
{
    [Header("GamePlay items")]
    [SerializeField]
    protected Text money;//money text to show
    [SerializeField]
    protected Text lives;//lives text to show
    [Header("Game over items"), Space(20)]
    public GameObject gameOver;//game over panel
    public Text levelText;//level text to show

    [Header("Pause menu")]
    [SerializeField]
    protected GameObject pausePanel;//pause panel

    [Header("Upgrade items")]
    [SerializeField]
    protected Text uCost;//upgrade cost
    [SerializeField]
    protected Text sCost;//sell cost
    [SerializeField]
    protected Button upgrade;//upgrade button
    [Header("Main Menu items")]
    [SerializeField]
    protected Slider volume;

}
