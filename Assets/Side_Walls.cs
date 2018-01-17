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

            hitInfo.gameObject.SendMessage("SetPlayerControl", 0, SendMessageOptions.RequireReceiver);
            if (Game_Manager.GetScore(1) == 10 || Game_Manager.GetScore(2) == 10 )
            {   // Game is over, dont restart the ball
                hitInfo.gameObject.SendMessage("PlaySound", 3, SendMessageOptions.RequireReceiver);                
                hitInfo.gameObject.SendMessage("EndGame", 1, SendMessageOptions.RequireReceiver);
            }
            else                
                hitInfo.gameObject.SendMessage("RestartBall", 1, SendMessageOptions.RequireReceiver);
        }
    }
}
