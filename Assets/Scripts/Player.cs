using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    InputManager inputManager;

    

    // Start is called before the first frame update
    void Start()
    {
        PrepareInput();


    }

    private void PrepareInput()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();

        if (inputManager != null)
        {
            inputManager.KeyPressedActionAddListener(InputHandler);
        }
    }

    private void InputHandler(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.UpArrow:
                MovePlayer(new Vector3(0,1f,0));
                break;

            case KeyCode.DownArrow:
                MovePlayer(new Vector3(0,-1f,0));
                break;

            case KeyCode.LeftArrow:
               MovePlayer(new Vector3(-1f,0,0));
                break;

            case KeyCode.RightArrow:
               MovePlayer(new Vector3(1f,0,0));
                break;

        
        
        }
    }

    private void MovePlayer(Vector3 position)
    {
       transform.position+=position;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    


   
}
