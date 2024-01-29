using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject GameOverScreen;
    public AudioSource seetc002;
    public AudioSource bgm;
    public AudioSource dead;

    [ContextMenu("Increase Score")]
    public void addscore()
    {
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();
        seetc002.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void gameOver()
    {
        GameOverScreen.SetActive(true);
        dead.Play();
        bgm.volume = -1;
    }
}
