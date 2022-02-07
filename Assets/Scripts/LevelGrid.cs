using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is reponsible for creating the grid for the level
public class LevelGrid : MonoBehaviour
{


    [SerializeField] private int numRows=20;
    [SerializeField] private int numCols=20;

    [SerializeField] GameObject groundObject;


    private Cell[,] gridArray;

   

    // Start is called before the first frame update
    void Start()
    {
        
        gridArray=new Cell[numRows,numCols];
        
        CreateGridData();
       

        Camera.main.transform.position=new Vector3((float)numRows/2-.5f,(float)numCols/2-.5f,-15);

    }

    private void CreateGridData()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {

                gridArray[row,col] = new Cell(row, col);
                
                Instantiate(groundObject,new Vector3((float)row-.5f,(float)col-.5f,0),Quaternion.identity);
                



            }

        }
    }


    public Cell GetGridCell(Vector2Int gridPosition)
    {
        return gridArray[gridPosition.x,gridPosition.y];

    }

    
}
