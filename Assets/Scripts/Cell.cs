using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    private Crate crate;
    private Goal goal;
    public Cell()
    {
        
    }

    public Crate Crate { get => crate; set => crate = value; }
    public Goal Goal { get => goal; set => goal = value; }

    public bool CheckIfCrateMatchesGoal()
    {
        if(Goal!=null && Crate!=null)
        {
           return true;
        }

        return false;


    }
   
   
}
