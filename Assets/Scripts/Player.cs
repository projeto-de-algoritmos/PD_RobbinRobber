using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager _gameManager;
    private MazeRenderer _mazeRenderer;
    private int i = 0;

    const int n = 4;
    const int maxCapacity = 50;
    int [,] data = new int [6, 51];

    [SerializeField]
    public struct fortuneACK
    {
        public int price;
        public int weight;
    }
    
    fortuneACK[] fortune = new fortuneACK[5];

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void KnapSack(int price, int weight) {

        if (i<5) 
        {
            fortune[i].price = price;
            fortune[i].weight = weight;

            //Debug.Log("i: " + i);
            //Debug.Log("Price: " + fortune[i].price);
            //Debug.Log("Weight: " + fortune[i].weight);

            i++;
        }
        
        if (i==5) 
        {
            //pausa o jogo
            _gameManager.gameOver = true;            

            //mostra a mochila com a melhor combinação possível
            for(int itemIndex =0; itemIndex <=n; itemIndex++) 
            {
                for(int capacity=0; capacity<=maxCapacity; capacity++)
                {
                    if(itemIndex == 0 || capacity == 0)
                    {
                        data[itemIndex, capacity] = 0;
                    }

                    else if(fortune[itemIndex].weight <= capacity)
                    {
                        data[itemIndex, capacity] = Mathf.Max(fortune[itemIndex].price + data[itemIndex-1, capacity - fortune[itemIndex].weight], data[itemIndex - 1, capacity]);
                    }
                    else 
                    {
                        data[itemIndex, capacity] = data[itemIndex-1, capacity];
                    }
                }
            }

            //Debug.Log("Max value: " + data[n, maxCapacity]);

            int i = n;
            int j = maxCapacity;
            int storage = 0;
            while (i > 0 && j > 0)
            {
                if (data[i, j] == data[i - 1, j])
                {
                }
                else
                {
                    //Debug.Log("Item Price: "+ fortune[i].price);
                    //Debug.Log("Item Weight: " + fortune[i].weight);
                    storage += fortune[i].weight;
                    j = j - fortune[i].weight;
                }
                i--;
            }

            //Debug.Log("Backpack storage: " + storage);

            //destroi player
            Destroy(this.gameObject);
        }
    }
}
