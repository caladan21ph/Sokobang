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
      if(Input.GetKey(KeyCode.UpArrow))
      {
          keyPressedAction?.Invoke(KeyCode.UpArrow);
      }

      if(Input.GetKey(KeyCode.DownArrow))
      {
          keyPressedAction?.Invoke(KeyCode.DownArrow);
      }
      if(Input.GetKey(KeyCode.LeftArrow))
      {
          keyPressedAction?.Invoke(KeyCode.LeftArrow);
      }

      if(Input.GetKey(KeyCode.RightArrow))
      {
          keyPressedAction?.Invoke(KeyCode.RightArrow);
      }

    }

    public void KeyPressedActionAddListener(UnityAction<KeyCode> listener)
    {
        keyPressedAction+=listener;
    }
}
