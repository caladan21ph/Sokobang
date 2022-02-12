using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    UnityAction<KeyCode> keyPressedAction;
    
    
    void Update()
    {
        GetInput();
        
    }

    private void GetInput()
    {
      if(Input.GetKeyDown(KeyCode.UpArrow))
      {
          keyPressedAction?.Invoke(KeyCode.UpArrow);
      }

      if(Input.GetKeyDown(KeyCode.DownArrow))
      {
          keyPressedAction?.Invoke(KeyCode.DownArrow);
      }
      if(Input.GetKeyDown(KeyCode.LeftArrow))
      {
          keyPressedAction?.Invoke(KeyCode.LeftArrow);
      }

      if(Input.GetKeyDown(KeyCode.RightArrow))
      {
          keyPressedAction?.Invoke(KeyCode.RightArrow);
      }

    }

    public void KeyPressedActionAddListener(UnityAction<KeyCode> listener)
    {
        keyPressedAction+=listener;
    }
}
