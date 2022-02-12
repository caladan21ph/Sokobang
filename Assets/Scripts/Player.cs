using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;



public class Player : MonoBehaviour
{
    private InputManager inputManager;
    private LevelManager levelManager;

    private Vector3 targetPosition;
    private bool movingToTargetPosition=false;

    [SerializeField] private float moveSpeed=.001f;
    
    [SerializeField] private Animator playerAnimator;
    private string lastDirection="Player_idle_down";

    

    

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
        //do not move if currently moving
        if(movingToTargetPosition) return;

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
    

       if(levelManager.CheckIfPositionHasObject(targetPosition)==false)
       {
           //position is not blocked move to target position
            movingToTargetPosition=true;
            // transform.position+=position;
            SetAnimation(position);
            levelManager.IncrementSteps();

       }
       else
        {
            //position has something so do something about it
            Crate crateInPosition = levelManager.GetCellCrate(targetPosition);
            Goal  goalInPosition=levelManager.GetCellGoal(targetPosition);

            PushCrate(position,crateInPosition);
           
            CheckGoal(targetPosition,goalInPosition);
            SetAnimation(position);
            levelManager.IncrementSteps();
          

           
            

        }



    }

    private void CheckGoal(Vector3 position, Goal goalInPosition)
    {
        if (goalInPosition != null && levelManager.GetCellCrate(position)==null)
        {
            //Debug.Log(objectInPosition.GetType().ToString());
            if (goalInPosition.tag == "Goal")
            {
                Debug.Log("Stepped on goal");
                movingToTargetPosition=true;
                
            }

        }
    }

    private bool PushCrate(Vector3 position, Crate objectInPosition)
    {
        //Check if object is crate, and if it is push it
      
        if (objectInPosition != null)
        {
            //Debug.Log(objectInPosition.GetType().ToString());
            if (objectInPosition.tag == "Crate")
            {
                // Debug.Log("pushed crate");
                if (objectInPosition.GetComponent<Crate>().Pushed(position) == true)
                {
                    movingToTargetPosition = true;
                    // transform.position+=position;
                    return true;
                }
            }

        }
        return false;
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (targetPosition != transform.position)
        {
            if (movingToTargetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                

            }

        }
        else
        {
            movingToTargetPosition = false;
            SetAnimation(new Vector3(0,0,0));
            SetFacing(lastDirection);

        }
    }


    private void SetAnimation(Vector3 position)
    {
       if(!movingToTargetPosition)
       {
           //player is not currently moving so set bools to false
           playerAnimator.SetBool("walkingForward",false);
           playerAnimator.SetBool("walkingBackward",false);
           playerAnimator.SetBool("walkingRight",false);
           playerAnimator.SetBool("walkingLeft",false);
       }
       else
       {
           if(position.y<0)
           {
               playerAnimator.SetBool("walkingForward",true);
               lastDirection="Player_idle_down";
               
           }
           if(position.y>0)
           {
               playerAnimator.SetBool("walkingBackward",true);
               lastDirection="Player_idle_up";
                
           }

           if(position.x>0)
           {
               playerAnimator.SetBool("walkingRight",true);
               lastDirection="Player_idle_right";
               
                
           }
           if(position.x<0)
           {
               playerAnimator.SetBool("walkingLeft",true);
               lastDirection="Player_idle_left";
               

           }


           
       }

      
    }

    public void SetFacing(string lastDirection)
    {
        playerAnimator.Play(lastDirection,0);
        
    }







}

enum Facing
{
    Front,
    Back,
    Right,
    Left
  

}
