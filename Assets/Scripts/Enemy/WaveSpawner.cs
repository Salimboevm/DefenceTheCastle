using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int alives = 0;//alive enemies

    [SerializeField]
    private Wave[] waves;//massive of waves 

    [SerializeField]
    private Transform location;//creating location
    [SerializeField]
    private float waveTime = 5f;//wave time between next wave
    private float countdown = 2f;//count down for next wave

    private int waveNum = 1;//wave number 

    private void Start()
    {
        waveNum = 0;//set wave num
        alives = 0;//set alive enemies
    }
    private void Update()
    {
        if (alives > 0)//check for alives
            return;

        if(countdown <= 0)//check for countdown
        {
            StartCoroutine(SpawnWave());//sif it is less than zero, spawn enemies
            countdown = waveTime;//set countdown
            return;
        }

        countdown -= Time.deltaTime;//calculate countdown
    }
    Wave wave;//wave 
    /// <summary>
    /// func to control spawning
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnWave()
    {
        
        PlayerStats.playerLevel++;//increse level
        if (waveNum < waves.Length)//check for wavenumber
        {
            wave = waves[waveNum];//set wave 
        }
        else
        {
            wave.count++;//increase num of enemies
        }
        for (int i = 0; i < wave.count; i++)//loop through enemies num
        {
            SpawnEnemy(wave.enemy);//spawn enemy
            yield return new WaitForSeconds(1f/wave.rate);//wait
        }

        waveNum++;//increase wave num
        

    }
    /// <summary>
    /// func to spawn enemy
    /// </summary>
    /// <param name="enemy"></param>
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, location.position, location.rotation);//create enemy
        alives++;//increase alive enemies
    }
}
