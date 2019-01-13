using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GameController : MonoBehaviour
{
    //string fileName = @"C:\Users\User\Desktop";
    public TextMeshProUGUI text;
    public GameObject menu;
    public GameObject scoreText;
    public GameObject canvas;
    public int score;
    public static int bestScore =0;
    public bool isStopped = false;
    public GameObject mainPlayer;
    public bool gameOver = false;
    public static bool start=true;

   

    void Start()
    {


        bestScore = 0;
            //readBest();
        isStopped = true;
        score = 0;
        scoreText = GameObject.FindGameObjectWithTag("Score");
        text = scoreText.GetComponent<TextMeshProUGUI>();
        text.text = "Score: " + score.ToString();

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        menu = canvas.transform.Find("Panel").gameObject;
        mainPlayer = GameObject.FindGameObjectWithTag("Player");

        if (start)
        {
            setMenuOnStart();
            showMenu();
            Time.timeScale = 0;
        }
        else
        {
            
            StartCoroutine(GameObject.FindGameObjectWithTag("AsteroidSpawner").GetComponent<AsteroidSpawner>().SpawnWaves());

        }


    
    }

    private void showMenu()
    {
        menu.SetActive(true);
        scoreText.SetActive(false);
    }

    private void hideMenu()
    {
        menu.SetActive(false);
        scoreText.SetActive(true);
    }

    void setMenuOnPause()
    {
        menu.transform.Find("GameState").GetComponent<TextMeshProUGUI>().text = "Game Paused";
        menu.transform.Find("MenuScore").GetComponent<TextMeshProUGUI>().text = text.text;
        menu.transform.Find("MenuText").GetComponent<TextMeshProUGUI>().text = "Press 'r' to resume";
    }

    void setMenuOnStart()
    {
        menu.transform.Find("GameState").GetComponent<TextMeshProUGUI>().text = "Asteroids";
        menu.transform.Find("MenuScore").GetComponent<TextMeshProUGUI>().text = "Best score: "+ bestScore.ToString();
        menu.transform.Find("MenuText").GetComponent<TextMeshProUGUI>().text = "Press space to start";
    }

    public void SetMenuOnGameOver()
    {
        menu.transform.Find("GameState").GetComponent<TextMeshProUGUI>().text = "Game Over";
        menu.transform.Find("MenuScore").GetComponent<TextMeshProUGUI>().text = text.text;
        menu.transform.Find("MenuText").GetComponent<TextMeshProUGUI>().text = "Press 'R' to restart";
    }

    private void Update()
    {
        if (mainPlayer == null)
        {
            Time.timeScale = 0;
            SetMenuOnGameOver();
            showMenu();
            gameOver = true;
        }

        if (Input.GetKeyDown("space") && start)
        {
   
            Time.timeScale = 1;
            isStopped = !isStopped;
            start = false;
            hideMenu();
            setMenuOnPause();
            StartCoroutine(GameObject.FindGameObjectWithTag("AsteroidSpawner").GetComponent<AsteroidSpawner>().SpawnWaves());
        }


        else if (Input.GetKeyDown("space") && !gameOver)
        {

            Time.timeScale = isStopped ? 1:0;
            isStopped = !isStopped;

            if (isStopped)
            {
                setMenuOnPause();
                showMenu();

            }
            else
            {
                hideMenu();

            }
        }

        if (Input.GetKeyDown("r") && gameOver)
        {
            SceneManager.LoadScene("Main");
            Time.timeScale = 1;
            if (score > bestScore)
            {
                //submitBest(score);
            }
            
        }

        
    }


    public void AddScore(int points)
    {
        score += points;
        text.text = "Score: " + score.ToString();

    }

    /*public void submitBest(int score)
    {

        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
        {
            writer.Write(score);
            
        }
    }

    public int readBest()
    {

        int readScore = 0;

        if (File.Exists(fileName))
        {

            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                readScore = (int)reader.ReadSingle();

            }
        }


        return readScore;
    }*/
}
