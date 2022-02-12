using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public List<GameObject> cratePositions;
    public List<GameObject> goalPositions;
  
    public GameObject cratePrefab;
    public GameObject goalPrefab;

    public LevelManager levelManager;
   

    // Start is called before the first frame update
    void Start()
    {
       

        InstantiateCrates();
        InstantiateGoals();
        
    }

    private void InstantiateGoals()
    {
         foreach (GameObject goal in goalPositions)
       {
           Goal goalInstance=Instantiate(goalPrefab,goal.transform.position,Quaternion.identity,transform).GetComponent<Goal>();
           Cell gridCell=levelManager.objectGrid[Vector2Int.FloorToInt(goal.transform.position)];
           gridCell.Goal=goalInstance;
          
           
           

       }
       
    }

    private void InstantiateCrates()
    {
       foreach (GameObject crate in cratePositions)
       {
           Crate crateInstance=Instantiate(cratePrefab,crate.transform.position,Quaternion.identity,transform).GetComponent<Crate>();
           Cell gridCell=levelManager.objectGrid[Vector2Int.FloorToInt(crate.transform.position)];
           gridCell.Crate=crateInstance;
          
           
           

       }
    }

   
}
