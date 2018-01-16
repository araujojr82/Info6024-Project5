using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_Walls : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if ( hitInfo.name == "Pongman" )
        {
            string wallName = transform.name;
            Game_Manager.Score(wallName);

            int score1 = Game_Manager.GetScore(1);
            int score2 = Game_Manager.GetScore(2);

            if ( score1 >= 10 || score2 >= 10 )
            {   // Game is over, dont restart the ball
                //    // Do Nothing, its the end of the game
                hitInfo.gameObject.SendMessage("PlaySound", 3, SendMessageOptions.RequireReceiver);
                hitInfo.gameObject.SendMessage("EndGame", 1, SendMessageOptions.RequireReceiver);
            }
            else           
                hitInfo.gameObject.SendMessage("RestartBall", 1, SendMessageOptions.RequireReceiver);
        }
    }
}
