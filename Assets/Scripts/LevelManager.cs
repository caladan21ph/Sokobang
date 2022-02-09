using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GridLayout gridLayout;
    public Tilemap wallTilemap;
    
    public Tilemap objectTilemap;

    public Tilemap floorTilemap;

  

    

    public Dictionary<Vector2Int,Cell> objectGrid=new Dictionary<Vector2Int, Cell>();
    
    


    private void Awake() 
    {
       

         PrepareObjectGrid();


        
    }

   

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int playerPos = GetObjectInGridPosition(player.transform.position);



        Debug.Log(playerPos);

       

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

    private void AddWallsToObjectGrid()
    {
        Debug.Log(wallTilemap.origin);
        for (int i = wallTilemap.origin.x; i < wallTilemap.size.x; i++)
        {
          
            for (int j = wallTilemap.origin.y; j < wallTilemap.size.y; j++)
            {
                TileBase tile = wallTilemap.GetTile(Vector3Int.FloorToInt(new Vector3(i, j, 0)));
                // Debug.Log(tile);
                

            }

        }
    }

    public Vector3Int GetObjectInGridPosition(Vector3 objectPosition)
    {
        return gridLayout.WorldToCell(objectPosition);
       
    }

    public  bool CheckIfPositionIsBlocked(Vector3 position)
    {
        // Debug.Log(Vector3Int.FloorToInt(position-new Vector3(wallTilemap.size.x/2,wallTilemap.size.y/2,0)));

        Vector3Int adjustedPosition=Vector3Int.FloorToInt(position-new Vector3(wallTilemap.size.x/2,wallTilemap.size.y/2,0));
       
        Cell targetCell=objectGrid[Vector2Int.FloorToInt(position)];
        if(targetCell.gameObject!=null || wallTilemap.GetTile(adjustedPosition)!=null)
        {
            return true;
        }
        



        return false;
    }


    public GameObject GetCellGameObject(Vector3 position)
    {
        return objectGrid[Vector2Int.FloorToInt(position)].gameObject;
    }

   





   
   
}
