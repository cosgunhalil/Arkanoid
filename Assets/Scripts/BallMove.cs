using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    private float randVal;
    private static Rigidbody2D rigidBody;
    int seconds = 0;
    static float displayTimer = 0;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        randVal = Random.value;
        if(randVal > 0.5f) 
        {
            randVal = -1;
        }
        else
        {
            randVal = 1;
        }

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(new Vector3(9.8f * 20f * randVal, 9.8f * 25f, 0));
        displayTimer = 0;
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        displayTimer += Time.deltaTime;
    }

    IEnumerator timer()
    {
        while(true)
        {
            secondsCount();
            ScoreSystem.addScoreTime(seconds / 5);
            if(seconds % 5 == 0)
            {
                increaseSpeed();
            }
            yield return new WaitForSecondsRealtime(3);
        }
    }

    private void secondsCount()
    {
        seconds++;
    }

    private void increaseSpeed()
    {
       if(rigidBody.velocity.y >= 0)
       {
            if(rigidBody.velocity.x >= 0)
            {
                rigidBody.velocity += new Vector2(0.5f, 0.5f);
            }
            else if(rigidBody.velocity.x < 0)
            {
                rigidBody.velocity += new Vector2(-0.5f, 0.5f);
            }
       }
       else if(rigidBody.velocity.y < 0)
       {
            if(rigidBody.velocity.x >= 0)
            {
                rigidBody.velocity += new Vector2(0.5f, -0.5f);
            }
            else if(rigidBody.velocity.x < 0)
            {
                rigidBody.velocity += new Vector2(-0.5f, -0.5f);
            }
       } 
    }

    static public float getDisplayTime()
    {
        return displayTimer;
    }

    public static float GetRigidbody2Dy()
    {
        return rigidBody.velocity.y;
    }

    public static float GetRigidbody2Dx()
    {
        return rigidBody.velocity.x;
    }

    public static float GetRigidbody2DVel()
    {
        return Mathf.Sqrt((rigidBody.velocity.x * rigidBody.velocity.x) + (rigidBody.velocity.y * rigidBody.velocity.y));
    }
}
