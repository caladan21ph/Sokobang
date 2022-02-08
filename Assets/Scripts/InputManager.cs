using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    UnityAction<KeyCode> keyPressedAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
