using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    //public Collider triggerCollider;
    Animator doors;

    // Start is called before the first frame update
    void Start()
    {
        doors = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Tigger enter ok yes");
            doors.SetBool("openDoor", true);
        }
        
    }

}
