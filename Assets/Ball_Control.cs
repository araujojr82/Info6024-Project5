using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Control : MonoBehaviour {

    private Rigidbody2D BallRB2d;
    private Vector2 BallSpeed;

    public int underPlayer = 0;

    public AudioClip[] audioClips;
    AudioSource audioSource;

    void PlayerHit()
    {
        if( underPlayer == 1 )
            Game_Manager.Score("Right_Wall");
        if (underPlayer == 2)
            Game_Manager.Score("Left_Wall");

        if (Game_Manager.GetScore(1) == 10  || Game_Manager.GetScore(2) == 10)
        {   // Game is over, dont restart the ball
            PlaySound(3);
            EndGame();
        }
    }

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
    void Start ()
    {
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

    void SetPlayerControl( int Player )
    {
        underPlayer = Player;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player") )
        {
            if (coll.collider.name == "Player1")
                SetPlayerControl(1);                
            else
                SetPlayerControl(2);

            PlaySound(0);
        }
        else if(coll.collider.CompareTag("wall"))
        {
            PlaySound(1);
        }
    }
    void Update()
    {
        Vector2 moveDirection = BallRB2d.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
