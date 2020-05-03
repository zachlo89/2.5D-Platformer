using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinText, _livesText;
    private int _defaultScore = 0;
    private int _defaultLives = 0;


    void Start() 
    {
        _coinText.text = "Coins: " + _defaultScore;
        _livesText.text = "Lives: " + _defaultLives;
    }

    public void UpdateCoinDisplay(int coins)
    {
        // assign new text here
        _coinText.text = "Coins: " + coins.ToString(); 
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}
