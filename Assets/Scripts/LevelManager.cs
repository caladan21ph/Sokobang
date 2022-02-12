using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GridLayout gridLayout;
    public Tilemap wallTilemap;
    
    public Tilemap objectTilemap;

    public Tilemap floorTilemap;

    public CrateManager crateManager;

    private int numberOfMoves=0;
    
    private UnityAction movesIncrementedAction;

  

    

    public Dictionary<Vector2Int,Cell> objectGrid=new Dictionary<Vector2Int, Cell>();

    public int NumberOfMoves { get => numberOfMoves; set => numberOfMoves = value; }

    private void Awake() 
    {
       

      


        
    }

   

    // Start is called before the first frame update
    void Start()
    {
       

        PrepareObjectGrid();


    }

    private void PrepareObjectGrid()
    {
        for (int row = 0; row < floorTilemap.size.y; row++)
        {
            for (int col = 0; col < floorTilemap.size.x; col++)
            {

                objectGrid[new Vector2Int(col, row)] = new Cell();

            }

        }

        
    }

    

    public Vector3Int GetObjectInGridPosition(Vector3 objectPosition)
    {
        return gridLayout.WorldToCell(objectPosition);
       
    }

    public  bool CheckIfPositionHasObject(Vector3 position)
    {
        // Debug.Log(Vector3Int.FloorToInt(position-new Vector3(wallTilemap.size.x/2,wallTilemap.size.y/2,0)));

        Vector3Int adjustedPosition=Vector3Int.FloorToInt(position-new Vector3(wallTilemap.size.x/2,wallTilemap.size.y/2,0));
       
        Cell targetCell=objectGrid[Vector2Int.FloorToInt(position)];
        if(targetCell.Crate!=null || targetCell.Goal!=null || wallTilemap.GetTile(adjustedPosition)!=null)
        {
            return true;
        }
        



        return false;
    }



    public Cell GetCell(Vector3 position)
    {
        return  objectGrid[Vector2Int.FloorToInt(position)];
    }


    public void CheckIfLevelComplete()
    {
        List<Vector3> goalPositions=new List<Vector3>();

        //get all positions and store them in a list
        foreach (GameObject goal in crateManager.goalPositions)
        {
            goalPositions.Add(goal.transform.position);
        }

        //for each position in the list check cell if has both crate and goal

        int amountOfGoalsFilled=0;

        foreach (Vector3 position in goalPositions)
        {
            if(GetCell(position).Crate!=null && GetCell(position).Goal!=null)
            {
               
                amountOfGoalsFilled+=1;
            }
            
        }

        if(amountOfGoalsFilled>=goalPositions.Count)
        {
            Debug.Log("Level Complete!");
        }

    }

    public void IncrementSteps()
    {
        numberOfMoves+=1;
        movesIncrementedAction.Invoke();
    }


    public void AddMovesIncrementedActionListener(UnityAction listener)
    {
        movesIncrementedAction+=listener;
    }
    

   





   
   
}
