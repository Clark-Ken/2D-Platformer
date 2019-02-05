using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;

    public GameObject[] rooms;  //index 0 - LR, index 1 - LRB, index 2 - LRT, index 3 - LRTB
    public GameObject start;
    public GameObject finish;

    public LayerMask room;

    private int direction;
    private int downCounter;

    public float moveAmount;
    private float timeBtwRoom;
    public float startTimeBtwRoom;
    //Boarder
    public float minX;
    public float maxX;
    public float minY;

    public bool stopGeneration = false;

    // Start is called before the first frame update
    void Start()
    {
        int rndStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[rndStartingPos].position;

        Instantiate(rooms[0], transform.position, Quaternion.identity);
        Instantiate(start, transform.position, Quaternion.identity);

        direction = Random.Range(1, 8);
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
                Instantiate(finish, transform.position, Quaternion.identity);
            }
        }        
    }
}
