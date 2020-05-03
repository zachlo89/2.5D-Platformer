using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 25.0f;
    private float _yVelocity; // nn var to cache Y velocity
    private bool _canDoubleJump;

    // ** var for player coins
    [SerializeField] private int _coins = 0;
    private UIManager _uiManager;

    // ** var for lives
    [SerializeField] private int _lives = 3;
    [SerializeField] private GameObject _deathPlatform;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("UI manager is NULL");
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    void Update()
    {
        // get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // define direction based on that input
        Vector3 direction = new Vector3(horizontalInput, 0, 0); // becomes either -5 or 5

        // velocity is direction with speed
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded == true)
        {
            // if I hit space key
            // jump; tk velocity.y and define a jump height.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // _velocity.y = _jumpHeight;
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            // ** DBL JUMP
            // chk if u can jump again; aka dbl jump
            // tk curr yVelocity += jumpheight
            // only do once by creating a bool set to T or F
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight; // doubling our jump height; can use multiplier * 2 to double height.
                    _canDoubleJump = false;
                }
            }
            // _velocity.y -= _gravity; // apply gravity to velocity on y; velocity.y - _gravity;
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        
        // call move method; move based on that direction
        // everything above happen before move called cuz nn to calc how to move 1st.
        _controller.Move(velocity * Time.deltaTime);
        // _controller.Move(direction * Time.deltaTime);
    }


    public void AddCoins()
    {
        _coins += 1;
        _uiManager.UpdateCoinDisplay(_coins);
    }


    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }

        // update UI display
        _uiManager.UpdateLivesDisplay(_lives); 
    }
}
