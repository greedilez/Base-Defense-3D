using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWalkingAnimatorHandler : MonoBehaviour
{
    [SerializeField] private WeaponChanger _weaponChanger;

    [SerializeField] private PlayerWalkHandler _playerWalkHandler;

    private void Update() => TriggerWalkAnimation();

    private void TriggerWalkAnimation() {
        string boolKey = "Walk";
        _weaponChanger.CurrentGun.WeaponAnimator.SetBool(boolKey, _playerWalkHandler.IsWalking);
    }
}
