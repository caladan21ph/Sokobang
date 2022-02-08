using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public List<GameObject> cratePositions;
  
    public GameObject cratePrefab;

    public LevelManager levelManager;
   

    // Start is called before the first frame update
    void Start()
    {
       

        InstantiateCrates();
        
    }

    private void InstantiateCrates()
    {
       foreach (GameObject crate in cratePositions)
       {
           GameObject crateInstance=Instantiate(cratePrefab,crate.transform.position,Quaternion.identity,transform);
           Cell gridCell=levelManager.objectGrid[Vector2Int.FloorToInt(crate.transform.position)];
           gridCell.gameObject=crateInstance;
          
           
           

       }
    }

   
}
