using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public Vector3 startPos;

    public GameObject[] rooms;  //index 0 - LR, index 1 - LRB, index 2 - LRT, index 3 - LRTB
    public GameObject player;
    public GameObject finish;
    public Text scoreText;

    public LayerMask room;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject confirmationPanel;

    private int direction;
    private int downCounter;
    public int score;

    public float moveAmount;
    private float timeBtwRoom;
    public float startTimeBtwRoom;
    //Boarder
    public float minX;
    public float maxX;
    public float minY;

    public bool stopGeneration = false;

    public GameObject audioManager;

    // Start is called before the first frame update
    void Start()
    {
        int rndStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[rndStartingPos].position;
        startPos = transform.position;

        gameOverPanel.SetActive(false);

        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 8);

        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "SCORE: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwRoom <= 0 && stopGeneration == false)
        {
            MoveRoom();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime; 
        }
    }

    void MoveRoom()
    {
        if (direction == 1 || direction == 2 || direction == 3)   //Move right
        {
            if (transform.position.x < maxX)
            {
                downCounter = 0;

                Vector2 newPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPosition;

                int rndRoom = Random.Range(0, rooms.Length);
                Instantiate(rooms[rndRoom], transform.position, Quaternion.identity);

                direction = Random.Range(1, 8);

                if (direction == 4)
                {
                    direction = 2;
                }
                else if (direction == 5)
                {
                    direction = 3;
                }
                else if (direction == 6)
                {
                    direction = 7;
                }
            }
            else
            {
                direction = 7;
            }
        }
        else if (direction == 4 || direction == 5 || direction == 6)   //Move left
        {
            if (transform.position.x > minX)
            {
                downCounter = 0;

                Vector2 newPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPosition;

                int rndRoom = Random.Range(0, rooms.Length);
                Instantiate(rooms[rndRoom], transform.position, Quaternion.identity);

                direction = Random.Range(4, 8);
            }
            else
            {
                direction = 7;
            }   
        }
        else if (direction == 7)   //Move down
        {
            downCounter++;

            if (transform.position.y > minY)
            {
                //Invisible circle only detects rooms
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);

                //If the room doesn't have a bottom opening
                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    if (downCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        int rndBottomRoom = Random.Range(1, 4);

                        if (rndBottomRoom == 2)
                        {
                            rndBottomRoom = 1;
                        }

                        Instantiate(rooms[rndBottomRoom], transform.position, Quaternion.identity);
                    }
                }

                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPosition;

                int rndRoom = Random.Range(2, 3);
                Instantiate(rooms[rndRoom], transform.position, Quaternion.identity);

                direction = Random.Range(1, 8);
            }
            else    //Stop generation
            {
                stopGeneration = true;
                player.transform.position = startPos;
                Instantiate(finish, transform.position, Quaternion.identity);
            }
        }        
    }

    public void RespawnPlayer()
    {
        if (stopGeneration == true)
        {
            player.transform.position = startPos;
        }
    }

    public void NextLevel()
    {
        score = score + 100;
        PlayerPrefs.SetInt("Score", score);
    }

    public void ContinueToSaveScore()
    {
        Time.timeScale = 1;
        Destroy(audioManager);
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePausePanel()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void OpenConfirmationPanel()
    {
        confirmationPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Destroy(audioManager);
        SceneManager.LoadScene(0);
    }

    public void CloseConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
    }
}
