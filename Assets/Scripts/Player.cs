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
        inputManager=GameObject.FindObjectOfType<InputManager>();

        if(inputManager!=null)
        {
            inputManager.KeyPressedActionAddListener(InputHandler);
        }
        
        
    }

    private void InputHandler(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.UpArrow:
                Debug.Log("Move up");
                break;

            case KeyCode.DownArrow:
                Debug.Log("Move down");
                break;

            case KeyCode.LeftArrow:
                Debug.Log("Move left");
                break;

            case KeyCode.RightArrow:
                Debug.Log("Move right");
                break;

        
        
        }
    }
       

    // Update is called once per frame
    void Update()
    {
        
    }

    


   
}
