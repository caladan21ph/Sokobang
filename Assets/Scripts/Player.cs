using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    InputManager inputManager;
    LevelManager levelManager;

    

    // Start is called before the first frame update
    void Start()
    {
        levelManager=GameObject.FindObjectOfType<LevelManager>();

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
       //check if object in target position before moving player
       Vector3 targetPosition=transform.position+position;
       Debug.Log("Target position:"+ Vector3Int.FloorToInt(targetPosition));

       if(levelManager.CheckIfPositionIsBlocked(targetPosition)==false)
       {
            transform.position+=position;

       }
       else
       {
           //Check if object is crate, and if it is push it
           GameObject objectInPosition=levelManager.GetCellGameObject(targetPosition);
        //    Debug.Log(objectInPosition.GetType().ToString());
           if(objectInPosition.tag=="Crate")
           {
               Debug.Log("pushed crate");
               objectInPosition.GetComponent<Crate>().Pushed(position);
           }

       }
       

      
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    


   
}
