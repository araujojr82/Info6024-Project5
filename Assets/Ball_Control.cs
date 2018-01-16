using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Control : MonoBehaviour {

    private Rigidbody2D BallRB2d;
    private Vector2 BallSpeed;

    public AudioClip[] audioClips;
    AudioSource audioSource;

    void StartBall()
    {
        float randX = Random.Range(0, 2);
        float randY = Random.Range(0, 2);
        if (randX < 1)
        {
            if (randY < 1) BallRB2d.AddForce(new Vector2(20, 15));
            else           BallRB2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            if (randY < 1) BallRB2d.AddForce(new Vector2(-20, 15));
            else           BallRB2d.AddForce(new Vector2(-20, -15));
        }
    }
    
    // Use this for initialization
    void Start () {
        BallRB2d = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2);

        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(int clip)
    {        
        audioSource.PlayOneShot(audioClips[clip], 0.7f);
    }

    void RestartBall()
    {
        ResetBall();
        Invoke("StartBall", 1);
    }

    void EndGame()
    {
        ResetBall();
    }

    void ResetBall()
    {
        BallSpeed = Vector2.zero;
        BallRB2d.velocity = BallSpeed;
        transform.position = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player") )
        {
            PlaySound(0);
        }
        else if(coll.collider.CompareTag("wall"))
        {
            PlaySound(1);
        }
    }
}
