using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is reponsible for creating the grid for the level
public class LevelGrid : MonoBehaviour
{


    [SerializeField] private int numRows=20;
    [SerializeField] private int numCols=20;


    private Cell[,] gridArray;

    // Start is called before the first frame update
    void Start()
    {
        CreateGridData();

    }

    private void CreateGridData()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {

                gridArray[row, col] = new Cell(row, col);
                



            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
