using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    private int _defaultScore = 0;


    void Start() 
    {
        _coinText.text = "Coins: " + _defaultScore;
    }

    public void UpdateCoinDisplay(int coins)
    {
        // assign new text here
        _coinText.text = "Coins: " + coins.ToString(); 
    }

}
