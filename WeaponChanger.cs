using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private Weapon[] _availableWeapons;

    [SerializeField] private KeyCode[] _weaponChangingButtons;

    public int CurrentWeaponIndex{ get; private set; }

    private bool _weaponHasBeenChanged = false;

    private float _betweenWeaponChangeDelay = 1;

    public UnityEvent OnWeaponChanged;

    [SerializeField] private ShootingHandler _shootingHandler;

    [SerializeField] private ReloadHandler _reloadingHandler;

    public Weapon CurrentGun{ get; private set; }

    private void Awake() {
        CurrentGun = _availableWeapons[CurrentWeaponIndex];
    }

    private void Update() {
        WaitForButtonPress();
    }

    private void WaitForButtonPress() {
        if (Input.anyKeyDown && !_reloadingHandler.IsReloading && PlayerDeathHandler.Instance.IsPlayerAlive) {
            for (int i = 0; i < _weaponChangingButtons.Length; i++) {
                if (Input.GetKeyDown(_weaponChangingButtons[i])) {
                    ChangeWeapon(i);
                }
            }
        } 
    }

    public void ChangeWeapon(int targetIndex) {
        if (!_weaponHasBeenChanged && CurrentWeaponIndex != targetIndex) {
            CurrentWeaponIndex = targetIndex;
            CurrentGun = _availableWeapons[targetIndex];
            UpdateCurrentGun();
            _weaponHasBeenChanged = true;
            StartCoroutine(BetweenWeaponChangeDelay());
            OnWeaponChanged.Invoke();
            float weaponChangingDelay = 1.375f;
            _shootingHandler.ChangeCanShootStateAfterWeaponSwap(weaponChangingDelay);
        }
    }

    private void UpdateCurrentGun() {
        for (int i = 0; i < _availableWeapons.Length; i++) {
            if(i == CurrentWeaponIndex) {
                _availableWeapons[i].gameObject.SetActive(true);
                continue;
            }
            _availableWeapons[i].gameObject.SetActive(false);
        }
    }

    private IEnumerator BetweenWeaponChangeDelay() {
        yield return new WaitForSeconds(_betweenWeaponChangeDelay); _weaponHasBeenChanged = false;
    }
}
