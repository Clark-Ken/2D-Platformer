using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillInEmptySpaces : MonoBehaviour
{
    public LayerMask emptyRooms;
    public LevelGeneration levelGeneration;

    public GameObject[] closedRooms;

    public int notClosedChanse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, emptyRooms);

        if (roomDetection == null && levelGeneration.stopGeneration == true)
        {
            int rndNumb = Random.Range(0, notClosedChanse + 3);

            if (rndNumb >= notClosedChanse)
            {
                //Spawn in random room
                int rndRoom = Random.Range(0, levelGeneration.rooms.Length);
                Instantiate(levelGeneration.rooms[rndRoom], transform.position, Quaternion.identity);
                //Rooms won't spawn endlessly
                Destroy(gameObject);
            }
            else
            {
                int rndCRoom = Random.Range(0, closedRooms.Length);
                Instantiate(closedRooms[rndCRoom], transform.position, Quaternion.identity);
                //Rooms won't spawn endlessly
                Destroy(gameObject);
            }
            
        }
    }
}
