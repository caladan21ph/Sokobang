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

        //Check if there is object in target position
        if(levelManager.CheckIfPositionIsBlocked(targetPosition)==false)
        {
            //remove crate from current cell and move to target cell
            levelManager.objectGrid[Vector2Int.FloorToInt(transform.position)].crate=null;
            levelManager.objectGrid[Vector2Int.FloorToInt(targetPosition)].crate=this.gameObject.GetComponent<Crate>();
            //position is not blocked.Move crate

            // transform.position=targetPosition;
            movingToTargetPosition=true;
            
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
