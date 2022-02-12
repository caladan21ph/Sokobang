using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    LevelManager levelManager;

    [SerializeField] private TextMeshProUGUI moveStatText;
    void Start()
    {
        levelManager=GameObject.FindObjectOfType<LevelManager>();
        levelManager.AddMovesIncrementedActionListener(UpdateMoveStatText);
        
    }


    private void UpdateMoveStatText()
    {
        moveStatText.text="Number of Moves:"+levelManager.NumberOfMoves;
    }

   
}
