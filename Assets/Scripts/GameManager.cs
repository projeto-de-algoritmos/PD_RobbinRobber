using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;
    public GameObject mazeRenderer;
    public bool gameIsOn = false;

    void Update() 
    {
        if(gameOver == true) 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(gameIsOn == false) 
                {
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                    Instantiate(mazeRenderer, Vector3.zero, Quaternion.identity);
                    gameOver = false;
                    gameIsOn = true;
                }

                else 
                {
                    FindObjectOfType<BackpackPopUp>().HideInfo();
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                    Instantiate(mazeRenderer, Vector3.zero, Quaternion.identity);
                    gameOver = false;
                }
            }
        }
    }
}
