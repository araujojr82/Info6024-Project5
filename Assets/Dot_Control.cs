using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot_Control : MonoBehaviour {

	void Start()
    {
        newRandomPosition();
    }

    void newRandomPosition()
    {
        Vector2 position;
        position.x = Random.Range(-7.0f, 7.0f);
        position.y = Random.Range(-4.4f, 4.4f);

        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Pongman")
        {
            newRandomPosition();
            hitInfo.gameObject.SendMessage("PlaySound", 2, SendMessageOptions.RequireReceiver);
            hitInfo.gameObject.SendMessage("PlayerHit", null, SendMessageOptions.RequireReceiver);
        }
    }


}
