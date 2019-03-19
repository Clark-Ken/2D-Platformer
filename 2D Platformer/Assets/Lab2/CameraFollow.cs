using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 cameraOffset;

    public float smoothSpeed = 10f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        //transform.LookAt(player);

        //transform.rotation = player.rotation;
    }
}
