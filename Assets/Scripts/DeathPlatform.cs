using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _playerStartPos;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            other.transform.position = _playerStartPos.transform.position;
        }
    }
}
