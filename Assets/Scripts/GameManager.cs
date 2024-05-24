using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;
public class GameManager : MonoBehaviour
{
    private WeaponContoller weapon;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        weapon = GameObject.Find("M1911").GetComponent<WeaponContoller>();
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void Win()
    {
        SaveHighScore();
        SceneManager.LoadScene("Menu");
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        SaveHighScore();
        weapon.DestroyWeapon();
        GameObject.Find("Main Camera").GetComponent<FollowPlayer>().enabled = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyAI>().enabled = false;
            enemy.GetComponent<EnemyWeapon>().enabled = false;
        }
    }

    private void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
