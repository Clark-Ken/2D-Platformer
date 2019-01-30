using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillInEmptySpaces : MonoBehaviour
{
    public LayerMask emptyRooms;
    public LevelGeneration levelGeneration;

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
            //Spawn in random room
            int rndRoom = Random.Range(0, levelGeneration.rooms.Length);
            Instantiate(levelGeneration.rooms[rndRoom], transform.position, Quaternion.identity);
            //Rooms won't spawn endlessly
            Destroy(gameObject);
        }
    }
}
