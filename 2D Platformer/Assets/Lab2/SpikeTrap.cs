using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject spikes;

    private bool inSpikeZone = false;

    public float maxHight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inSpikeZone && spikes.transform.position.y <= maxHight)
        {
            spikes.transform.position = new Vector3(spikes.transform.position.x, spikes.transform.position.y + Time.deltaTime + 0.05f, spikes.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inSpikeZone = true;
        }
    }

    IEnumerator ActivateSpikes()
    {
        while (inSpikeZone)
        {
            return null;
        }

        return null;
    }
}
