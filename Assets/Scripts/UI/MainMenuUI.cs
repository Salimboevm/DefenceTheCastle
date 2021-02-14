using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UIManager
{
    [Header("Main Menu")]
    [SerializeField]
    private GameObject playB;//play button
    [SerializeField]
    private GameObject quitB;//quit button
    [SerializeField]
    private GameObject options;//options panel
    [SerializeField]
    private GameObject main;//options panel
/// <summary>
/// FUNC to start game, call from ui button
/// </summary>
    public void Play()
    {
        GameManager.instance.SceneLoader(1);//load scene
    }
    /// <summary>
    /// func to activate options panel
    /// </summary>
    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }
    ///go back to main menu
    public void GoBack()
    {
        main.SetActive(true);
        options.SetActive(false);
    }
    /// <summary>
    /// func to quit from game call from ui
    /// </summary>
    public void Quit()
    {
        Application.Quit();//quit game
    }
    private void Update()
    {
        AudioManager.instance.Volume(volume.value);
    }
}
