using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Control : MonoBehaviour {

    private Rigidbody2D BallRB2d;
    private Vector2 BallSpeed;

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
        Invoke("GoBall", 2);
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void ResetBall()
    {
        BallSpeed = Vector2.zero;
        BallRB2d.velocity = BallSpeed;
        transform.position = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            BallSpeed.x = BallRB2d.velocity.x;
            BallSpeed.y = (BallRB2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            BallRB2d.velocity = BallSpeed;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
