using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Fortune : MonoBehaviour
{

    public int price;
    public int weight;

    void Start()
    {
        price = Random.Range(20, 100);
        weight = Random.Range(15, 30);  
    }

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.tag == "Player")
        {
            Player knapSack = collision.GetComponent<Player>();
            
            if(knapSack != null) {
                knapSack.KnapSack(price, weight);
            }    

            Destroy(this.gameObject);
        }
    }

}
