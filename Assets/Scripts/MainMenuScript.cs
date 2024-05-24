using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public GameObject confirmation_window;
    public GameObject records_menu;
    public GameObject bird;
    public float speed = 1.0f;
    private Vector3 initialPosition = new Vector3(46.3f,17.5f,-81.6f);
    private Vector3 finalPosition = new Vector3(-33.9f,17.5f,-128.1f);
    private float journeyLength;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        bird.transform.position = initialPosition;
        journeyLength = Vector3.Distance(initialPosition, finalPosition);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceCovered = (Time.time - startTime) * speed;
        float journeyFraction = distanceCovered / journeyLength;
        bird.transform.position = Vector3.Lerp(initialPosition, finalPosition, journeyFraction);

        if (journeyFraction >= 1.0f)
        {
            // Move to next scene or do something else
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void ShowRecords()
    {
        if(!records_menu.activeSelf)
        {
            LoadHighScore();
            records_menu.SetActive(true);
        }
        else
        {
            records_menu.SetActive(false);
        }
    }

    private void LoadHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "Рекорд: " + highScore;
    }

    public void ExitGame()
    {
        confirmation_window.SetActive(true);
    }

    public void ConfirmExit()
    {
        Application.Quit();
    }

    public void CancelExit()
    {
        confirmation_window.SetActive(false);
    }
}
