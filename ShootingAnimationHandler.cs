using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAnimationHandler : MonoBehaviour
{
    [SerializeField] private WeaponChanger _weaponChanger;

    [SerializeField] private ShootingHandler _shootingHandler;

    [SerializeField] private AimingAnimationHandler _aimingAnimationHandler;

    private void Update() {
        TriggerShootingAnimation();
    }

    public void TriggerShootingAnimation() {
        if (_shootingHandler.CanShoot && !PauseHandler.Instance.IsPaused) {
            string boolKey = "Shooting";
            _weaponChanger.CurrentGun.WeaponAnimator.SetBool(boolKey, (_weaponChanger.CurrentGun.CurrentBulletsAmount > 0) ? _shootingHandler.IsShooting : false);
        }
    }
}
