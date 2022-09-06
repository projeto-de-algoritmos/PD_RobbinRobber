using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;
    public GameObject mazeRenderer;

    void Update() 
    {
        if(gameOver == true) 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                Instantiate(mazeRenderer, Vector3.zero, Quaternion.identity);
                gameOver = false;
            }
        }
    }
}
