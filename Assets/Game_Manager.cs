using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public static int Player1_Score = 0;
    public static int Player2_Score = 0;

    public GUISkin layout;

    GameObject theBall;

    // Use this for initialization
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("ball");
    }

    void ResetScore()
    {
        Player1_Score = 0;
        Player2_Score = 0;
    }

    public static int GetScore( int player )
    {
        if (player == 1)
            return Player1_Score;
        else if (player == 2)
            return Player2_Score;
        else 
            return 0;
    }

    public static void Score(string wallID)
    {
        if (wallID == "Right_Wall")
        {
            Player1_Score++;
        }
        else    // wallID == "Left_Wall"
        {
            Player2_Score++;
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width * 0.1f, 10, 100, 100), "" + Player1_Score);
        GUI.Label(new Rect(Screen.width * 0.86f, 10, 100, 100), "" + Player2_Score);

        if (GUI.Button(new Rect(Screen.width / 2 - 50, 10, 100, 40), "RESET"))
        {
            ResetScore();
            theBall.SendMessage("RestartBall", 1, SendMessageOptions.RequireReceiver);
        }

        if (Player1_Score == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 300, 200, 2000, 1000), "Player One Wins!");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (Player2_Score == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 300, 200, 2000, 1000), "Player Two Wins!");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

}