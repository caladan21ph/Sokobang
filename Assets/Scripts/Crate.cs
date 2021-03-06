using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    LevelManager levelManager;

    private Vector3 targetPosition;
    private bool movingToTargetPosition=false;

    [SerializeField] private float moveSpeed=10f;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition=transform.position;
        levelManager=GameObject.FindObjectOfType<LevelManager>();
        
    }

   
    public bool Pushed(Vector3 position)
    {
        targetPosition=transform.position+position;
        bool objectInPosition=levelManager.CheckIfPositionHasObject(targetPosition);
        Crate crateInPosition=levelManager.GetCell(targetPosition).Crate;
        Goal goalInPosition=levelManager.GetCell(targetPosition).Goal;

        //Check if there is object in target position
        if((objectInPosition==false) || (objectInPosition && goalInPosition && crateInPosition==null ))
        {
          
            //remove crate from current cell and move to target cell
            levelManager.objectGrid[Vector2Int.FloorToInt(transform.position)].Crate=null;
            levelManager.objectGrid[Vector2Int.FloorToInt(targetPosition)].Crate=this.gameObject.GetComponent<Crate>();
            
            
            //position is not blocked.Move crate
            movingToTargetPosition=true;

            //check if level complete everytime crate moves
            levelManager.CheckIfLevelComplete();
            
            return true;
          
        }
        

        return false;

        
    }

    private void Update()
    {
        MoveCrate();
    }


    private void MoveCrate()
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
        }
    }
}
