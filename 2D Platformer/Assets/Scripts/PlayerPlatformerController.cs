﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPlatformerController : PhysicsObject
{
    public float jumpTakeOffSpeed = 7;
    public float maxSpeed = 7;

    public GameObject gameOverPanel;
    public Text numberOfLivesText;

    public int numberOfLives;
    //private int highScore;

    public LevelGeneration lvlGen;

    // Start is called before the first frame update
    void Start()
    {
        numberOfLivesText.text = "LIVES: " + PlayerPrefs.GetInt("Lives");
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        targetVelocity = move * maxSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (numberOfLives > 0)
            {
                numberOfLives--;
                numberOfLivesText.text = "LIVES: " + numberOfLives;
                lvlGen.RespawnPlayer();
                PlayerPrefs.SetInt("Lives", numberOfLives);
            }
            else if (numberOfLives == 0)
            {
                numberOfLivesText.text = "LIVES: " + numberOfLives;
                Debug.Log("Game Over");
                gameOverPanel.SetActive(true);
                if (PlayerPrefs.GetInt("HighScore") < lvlGen.score)
                {
                    PlayerPrefs.SetInt("HighScore", lvlGen.score);
                }
            }
        }

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("RandomGeneration");
            lvlGen.NextLevel();
            numberOfLivesText.text = "LIVES: " + PlayerPrefs.GetInt("Lives");
        }
    }
}
