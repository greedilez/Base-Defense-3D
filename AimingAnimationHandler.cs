using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingAnimationHandler : MonoBehaviour
{
    [SerializeField] private WeaponChanger _weaponChanger;

    public bool IsAiming{ get; private set; }

    private void Update() {
        AdjustAimingState();
        TriggerAimingState();
    }

    private void AdjustAimingState() {
        int targetMouseKey = 1;
        IsAiming = Input.GetMouseButton(targetMouseKey);
    }

    private void TriggerAimingState() {
        string boolKey = "Aiming";
        _weaponChanger.CurrentGun.WeaponAnimator.SetBool(boolKey, IsAiming);
    }
}
