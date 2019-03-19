using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCube : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Force Animation");
            Vector3 vec = new Vector3(0, 1000, 0);

            rb.AddForce(vec, ForceMode.Acceleration);
            rb.useGravity = true;
        }
    }
}
