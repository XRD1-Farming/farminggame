using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFence : MonoBehaviour
{
    public float fenceWidth;
    private Vector3 startPos;
    public float speed = 1.0f;
    private float delay = 0.0f;

    private bool moving = false;
    private bool opening = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving) return;
        if(opening)
        {
            Vector3 end = new Vector3(startPos.x, startPos.y, startPos.z + fenceWidth);
            MoveDoor(end);
        }
        else
        {
            MoveDoor(startPos);
        }
    }

    void MoveDoor(Vector3 goalPos)
    {
        float dist = Vector3.Distance(transform.position, goalPos);
        if (dist > .1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        }
        else
        {
            if (opening)
            {
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    opening = false;
                }
            }
            else
            {
                moving = false;
                opening = true;
            }
        }
    }

    public bool Moving
    {
        get => moving;
        set => moving = value;
    }
}
