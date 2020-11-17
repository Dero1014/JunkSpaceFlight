using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public Player_Input player;
    public Spawn_Script ss;
    public TextMeshProUGUI scoreText;
    public GameObject restartButton;

    [Space(10)]
    public int score = 0;
    public static int highScore = 0;
    public int spawnTime = 0;

    public int numOfMeteors; 

    private float timeToSpawn = 0;
    
    void Start()
    {
        ss = GameObject.FindObjectOfType<Spawn_Script>();
        player = GameObject.FindObjectOfType<Player_Input>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn += Time.deltaTime;

        if (timeToSpawn > spawnTime)
        {
            ss.SpawnMeteors(numOfMeteors);
            timeToSpawn = 0;
        }

        if (score>highScore)
        {
            highScore = score;
        }

        scoreText.text = score.ToString();

        if (!player.gameObject.activeSelf)
        {
            //RESTART BUTTON & SHOW HIGH SCORE
            scoreText.text = "YOUR HIGH SCORE IS \n" + highScore.ToString();
            restartButton.SetActive(true);
        }
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }
}
