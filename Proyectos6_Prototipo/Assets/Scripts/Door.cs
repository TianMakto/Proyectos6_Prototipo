using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform openLocation;
    [SerializeField] float speed;
    Vector2 openPos;
    Vector2 closePos;
    bool open;
    bool close;
    float progress;


    private void Start()
    {
        closePos = transform.position;
        openPos = openLocation.position;
    }

    public void Open()
    {
        open = true;
    }

    public void Close()
    {
        close = true;
    }

    private void Update()
    {
        if(open)
        {
            progress += speed * Time.deltaTime;
            transform.position = Vector2.Lerp(closePos, openPos, progress);
            if ((Vector2)transform.position == openPos)
            {
                open = false;
                progress = 0;
            }
        }

        if (close)
        {
            progress += speed * Time.deltaTime;
            transform.position = Vector2.Lerp(openPos, closePos, speed);
            if ((Vector2)transform.position == closePos)
            {
                close = false;
                progress = 0;
            }
        }
    }
}
