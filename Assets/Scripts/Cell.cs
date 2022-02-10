using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    public Crate crate;
    public Goal goal;
    public Cell()
    {
        
    }

    public bool CheckIfCrateMatchesGoal()
    {
        if(goal!=null && crate!=null)
        {
           return true;
        }

        return false;


    }
   
   
}
