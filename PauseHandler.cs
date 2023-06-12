using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _keyToPause = KeyCode.Escape;

    [SerializeField] private TimeScaleHandler _timeScaleHandler;

    public bool IsPaused{ get; private set; }

    public static PauseHandler Instance;

    [SerializeField] private CursorLockHandler _cursorLockHandler;

    public UnityEvent OnPaused, OnUnpaused;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        TrackForTargetButton();
    }

    private void TrackForTargetButton() {
        if (Input.GetKeyDown(_keyToPause)) {
            SetPauseState(!IsPaused);
        }
    }

    public void SetPauseState(bool state) {
        float pausedState = 0;
        float normalState = 1;
        IsPaused = state;
        _timeScaleHandler.SetTimeScaleTo(state ? pausedState : normalState);
        UpdateCursorState();
        if (IsPaused) OnPaused.Invoke(); else OnUnpaused.Invoke();
    }

    private void UpdateCursorState() => _cursorLockHandler.SetCursorState(IsPaused);
}
