using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private InputManager inputManager;
    private LevelManager levelManager;

    private Vector3 targetPosition;
    private bool movingToTargetPosition=false;
    

    // Start is called before the first frame update
    void Start()
    {
        targetPosition=transform.position;
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
        targetPosition=transform.position+position;
    //    Debug.Log("Target position:"+ Vector3Int.FloorToInt(targetPosition));

       if(levelManager.CheckIfPositionIsBlocked(targetPosition)==false)
       {
            movingToTargetPosition=true;
            // transform.position+=position;

       }
       else
       {
           //Check if object is crate, and if it is push it
           GameObject objectInPosition=levelManager.GetCellGameObject(targetPosition);
           if(objectInPosition!=null)
           {
                //Debug.Log(objectInPosition.GetType().ToString());
                if(objectInPosition.tag=="Crate")
                {
                    // Debug.Log("pushed crate");
                    if(objectInPosition.GetComponent<Crate>().Pushed(position)==true)
                    {
                        movingToTargetPosition=true;
                        // transform.position+=position;
                    }
                }
               
           }
        

       }
       

      
    }

    private void Update() {
        if(targetPosition!=transform.position)
        {
            if(movingToTargetPosition)
            {
                transform.position=Vector3.MoveTowards(transform.position,targetPosition,10*Time.deltaTime);

            }
            
        }
        else
        {
            movingToTargetPosition=false;
        }
    }


  

    


   
}
