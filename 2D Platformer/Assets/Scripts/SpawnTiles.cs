using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    public GameObject[] tiles;

    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(0, tiles.Length);
        GameObject instance = Instantiate(tiles[rnd], transform.position, Quaternion.identity);
        instance.transform.parent = transform;  //child = parent, the instance variable is a child, of whatever spawned it (Room gameobject)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
