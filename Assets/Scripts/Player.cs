using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.Assertions;



public class Player : MonoBehaviour
{
    private InputManager inputManager;
    private LevelManager levelManager;

    private Vector3 targetPosition;
    private bool movingToTargetPosition=false;

    [SerializeField] private float moveSpeed=.001f;
    
    [SerializeField] private Animator playerAnimator;
   

    

    

        void Start()
    {
        targetPosition=transform.position;
        levelManager=GameObject.FindObjectOfType<LevelManager>();
        
        Assert.IsNotNull(levelManager);
        

        

        PrepareInput();


        

    }

    private void PrepareInput()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        Assert.IsNotNull(inputManager);

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
            Crate crateInPosition = levelManager.GetCell(targetPosition).Crate;
            Goal  goalInPosition=levelManager.GetCell(targetPosition).Goal;

            PushCrate(position,crateInPosition);
           
            CheckGoal(targetPosition,goalInPosition);
            SetAnimation(position);
           
          

           
            

        }



    }

    private void CheckGoal(Vector3 position, Goal goalInPosition)
    {
        //check if goal is in position and there is no crate
        if (goalInPosition != null && levelManager.GetCell(position).Crate==null)
        {
           
           movingToTargetPosition=true;
           levelManager.IncrementSteps();
        }
    }



    private bool PushCrate(Vector3 position, Crate crateInPosition)
    {
        //Check if object is crate, and if it is push it
      
        if (crateInPosition != null)
        {
            
                // Debug.Log("pushed crate");
                if (crateInPosition.GetComponent<Crate>().Pushed(position) == true)
                {
                    movingToTargetPosition = true;
                    // transform.position+=position;
                    return true;
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
            

        }
    }


    private void SetAnimation(Vector3 position)
    {
       if(!movingToTargetPosition)
        {
            ResetAnimationBools();
            
        }
        else
       {
          
           if(position.y<0)
           {
               playerAnimator.SetBool("walkingForward",true);
               
                playerAnimator.SetFloat("offSet",0);
               
           }
           if(position.y>0)
           {
               playerAnimator.SetBool("walkingBackward",true);
               
                playerAnimator.SetFloat("offSet",1);
                
           }

           if(position.x>0)
           {
               playerAnimator.SetBool("walkingRight",true);
              
               playerAnimator.SetFloat("offSet",.33f);
               
                
           }
           if(position.x<0)
           {
               playerAnimator.SetBool("walkingLeft",true);
              
                playerAnimator.SetFloat("offSet",.66f);
               

           }


           
       }

      
    }

    private void ResetAnimationBools()
    {
        //player is not currently moving so set bools to false
        playerAnimator.SetBool("walkingForward", false);
        playerAnimator.SetBool("walkingBackward", false);
        playerAnimator.SetBool("walkingRight", false);
        playerAnimator.SetBool("walkingLeft", false);
    }

    







}


