using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceTriggerForce : MonoBehaviour
{
    Animator door;

    public GameObject sphere;

    public float maxHight;
    public float timer = 3.0f;
    public float gravityOnTimer = 2.0f;

    bool gravityOn = false;
    bool animationDone = false;
    bool doOnce = false;
    bool sphereHasGravity = false;
    bool vectorChoosen = false;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door.GetBool("openPrize") == true && door.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && door.GetCurrentAnimatorStateInfo(0).IsName("PriceAnimation"))
        {            
            if (sphere.transform.position.y <= maxHight && !gravityOn)
            {
                sphere.transform.position = new Vector3(sphere.transform.position.x, sphere.transform.position.y + 0.1f + Time.deltaTime, sphere.transform.position.z);
            }
            else
            {
                animationDone = true;
            }
        }

        if (animationDone && !doOnce)
        {
            sphere.GetComponent<Rigidbody>().isKinematic = false;
            sphere.GetComponent<Rigidbody>().useGravity = true;

            doOnce = true;

            gravityOn = true;
        }

        if (gravityOn)
        {
            if (gravityOnTimer <= 0)
            {
                sphereHasGravity = true;
            }
            else
            {
                gravityOnTimer -= Time.deltaTime;
            }
        }

        if (sphereHasGravity && !vectorChoosen && timer <= 0)
        {
            int rng = Random.Range(100, 1001);

            int rVec = Random.Range(1,4);

            if (rVec == 1)
            {
                Vector3 vec = new Vector3(rng, 0, 0);
                sphere.GetComponent<Rigidbody>().AddForce(vec);

                vectorChoosen = true;
                timer = 3.0f;
            }
            else if (rVec == 2)
            {
                Vector3 vec = new Vector3(0, rng, 0);
                sphere.GetComponent<Rigidbody>().AddForce(vec);

                vectorChoosen = true;
                timer = 3.0f;
            }
            else if (rVec == 3)
            {
                Vector3 vec = new Vector3(0, 0, rng);
                sphere.GetComponent<Rigidbody>().AddForce(vec);

                vectorChoosen = true;
                timer = 3.0f;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            vectorChoosen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SetBool("openPrize", true);
        }
    }
}
