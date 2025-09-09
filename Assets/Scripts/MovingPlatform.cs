using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float timer;
    public float startTimer;
    public float speed;
    bool right;
    // Start is called before the first frame update
    void Start()
    {
        timer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            Right();
        }
        else
        {
            Left();
        }
        timer -= Time.deltaTime;
    }
    void Right()
    {
        Vector2 pos = transform.position;
        if(timer > 0)
        {
            pos.x += speed;
            transform.position = pos;
        }
        else
        {
            timer = startTimer;
            right = false;
        }
    }
    void Left()
    {
        Vector2 pos = transform.position;
        if (timer > 0)
        {
            pos.x -= speed;
            transform.position = pos;
        }
        else
        {
            timer = startTimer;
            right = true;
        }
    }
}
