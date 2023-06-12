using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class WalkingSoundHandler : MonoBehaviour
{
    [SerializeField] private AudioClip[] _walkingClips;

    [SerializeField] private AudioSource _targetAudioSource;

    private int _currentSoundIndex = 0;

    [SerializeField] private float _delayBetweenStep = 1;

    private bool _madeAStep = false;

    [SerializeField] private PlayerWalkHandler _playerWalkHandler;

    private void Update() {
        PlayWalkingSounds();
    }

    private void PlayWalkingSounds() {
        if (_playerWalkHandler.IsWalking) {
            if (!_madeAStep) {
                int firstStepIndex = 0;
                int lastStepIndex = 1;
                _targetAudioSource.PlayOneShot(_walkingClips[_currentSoundIndex]);
                _currentSoundIndex = (_currentSoundIndex == lastStepIndex) ? firstStepIndex : lastStepIndex;
                _madeAStep = true;
                StartCoroutine(BetweenStepDelay());
            }
        }
    }

    private IEnumerator BetweenStepDelay() {
        yield return new WaitForSeconds(_delayBetweenStep); _madeAStep = false;
    }
}
