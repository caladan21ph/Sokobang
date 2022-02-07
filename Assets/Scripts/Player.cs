using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        
    }

    private void GetInput()
    {
       if(Input.GetKeyDown(KeyCode.UpArrow)|Input.GetKeyDown(KeyCode.W))
       {
           PlayerMoveUp();
       }

       if(Input.GetKeyDown(KeyCode.DownArrow)|Input.GetKeyDown(KeyCode.S))
       {
           PlayerMoveDown();
       }

       if(Input.GetKeyDown(KeyCode.RightArrow)|Input.GetKeyDown(KeyCode.D))
       {
           PlayerMoveRight();
       }

       if(Input.GetKeyDown(KeyCode.LeftArrow)|Input.GetKeyDown(KeyCode.A))
       {
           PlayerMoveLeft();
       }
    }

    private void PlayerMoveLeft()
    {
        Debug.Log("player move left");
    }

    private void PlayerMoveRight()
    {
        Debug.Log("player move right");
    }

    private void PlayerMoveDown()
    {
        Debug.Log("player move down");
    }

    private void PlayerMoveUp()
    {
        Debug.Log("player move up");
        
    }
}
