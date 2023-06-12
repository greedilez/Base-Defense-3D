using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockHandler : MonoBehaviour
{
    [SerializeField] private bool _defaultCursorState = false;
    
    private void Awake() {
        SetCursorState(_defaultCursorState);
    }

    public void SetCursorState(bool state) {
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = state;
    }
}
