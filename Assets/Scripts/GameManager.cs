using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }

    public int level = 1;
    public int score = 0;
    public int lives = 3;
    Text scoreUI;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevel(1);
    }
    private void LoadLevel(int level)
    {
        this.level = level;
        score = 0;
        if (level > 2)
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            SceneManager.LoadScene("Lvl" + level);
        }
       // if (Input.GetKeyUp(KeyCode.Escape)) {SceneManager.LoadScene("Menu"); } else { }
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
    }
    private void ResetLevel()
    {
        
        this.paddle.ResetPaddle();
        this.ball.ResetBall();



      // for (int i = 0; i < this.bricks.Length; i++)
      // {
      //    this.bricks[i].ResetBrick();
      // }

    }
        private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        this.lives = 3;
        //NewGame();
    }

    public void Miss()
    {
        this.lives--;

        if (this.lives > 0)
        {
            ResetLevel();
            
        }
        else
        {
            GameOver();
        }
    }
    public void Hit(Brick brick)
    {
        this.score += brick.points;        
        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        Debug.Log("Score : " + score );
        scoreUI.text = "Score : " + score ;
        if (Cleared())
        {
            LoadLevel(this.level + 1);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }

    
}
