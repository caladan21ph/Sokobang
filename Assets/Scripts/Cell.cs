using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    private int row;
    private int col;
    private GameObject gameObject;

    public Cell(int row,int col)
    {
        this.row=row;
        this.col=col;
        this.gameObject=null;
        
    }
}
