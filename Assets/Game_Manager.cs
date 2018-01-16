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
        theBall = GameObject.FindGameObjectWithTag("Ball");
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
        GUI.Label(new Rect(Screen.width * 0.06f, 20, 100, 100), "" + Player1_Score);
        GUI.Label(new Rect(Screen.width * 0.9f, 20, 100, 100), "" + Player2_Score);

        if (GUI.Button(new Rect(Screen.width / 2 - 50, 20, 100, 40), "RESTART"))
        {
            Player1_Score = 0;
            Player2_Score = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (Player1_Score == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (Player2_Score == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

}