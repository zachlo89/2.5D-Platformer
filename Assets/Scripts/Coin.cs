using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    // on trigger enter
    // give the player coin
    // destroy obj
    // update UI

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.AddCoins();
            }
            
            Destroy(this.gameObject);
        }
    }
}
