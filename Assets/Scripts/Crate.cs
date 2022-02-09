using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager=GameObject.FindObjectOfType<LevelManager>();
        
    }

   
    public bool Pushed(Vector3 position)
    {
        Vector3 targetPosition=transform.position+position;

        //Check if there is object in target position
        if(levelManager.CheckIfPositionIsBlocked(targetPosition)==false)
        {
            levelManager.objectGrid[Vector2Int.FloorToInt(transform.position)].gameObject=null;
             levelManager.objectGrid[Vector2Int.FloorToInt(targetPosition)].gameObject=this.gameObject;
            //position is not blocked.Move crate
            transform.position=targetPosition;
            //remove crate from current cell and move to target cell
            return true;
          
        }

        return false;

        
    }
}
