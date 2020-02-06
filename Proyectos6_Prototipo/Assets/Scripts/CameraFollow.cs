using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float smoothSpeed;
    private Vector3 defaultOffset = new Vector3(0, 0, -10);

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = GameObject.FindGameObjectWithTag("Player").transform.position + defaultOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
