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

    public CrateManager crateManager;

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int playerPos=GetObjectInGridPosition(player.transform.position);
        
        Debug.Log(playerPos);
        

      
        
    }


    public Vector3Int GetObjectInGridPosition(Vector3 objectPosition)
    {
        return gridLayout.WorldToCell(objectPosition);
       
    }

    // Update is called once per frame
   
}
