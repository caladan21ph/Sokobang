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

    public Vector3Int GetObjectInGridPosition(Vector3 objectPosition)
    {
        return gridLayout.WorldToCell(objectPosition);
       
    }

    public  bool CheckIfPositionHasCrate(Vector3 position)
    {
        Cell targetCell=objectGrid[Vector2Int.FloorToInt(position)];
        if(targetCell.gameObject!=null)
        {
            return true;
        }

        return false;
    }

    // Update is called once per frame
   
}
