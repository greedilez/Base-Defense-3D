using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class ReloadHandler : MonoBehaviour
{
    [SerializeField] private WeaponChanger _weaponChanger;

    public UnityEvent OnReloaded;

    [SerializeField] private KeyCode _keyToReload = KeyCode.R;

    public bool IsReloading{ get; private set; }

    private void Update() {
        TrackForTargetReloadKey();
    }

    private void FixedUpdate() {
        UpdateReloadingAnimationState();
    }

    private void TrackForTargetReloadKey() {
        if (Input.GetKeyDown(_keyToReload)) {
            Reload();
        }
    }

    private void Reload() {
        Weapon currentWeapon = _weaponChanger.CurrentGun;
        if (!IsReloading) {
            if (currentWeapon.CurrentBulletsAmount < currentWeapon.BulletsAmount) {
                currentWeapon.OnStartedReloading.Invoke();
                StartCoroutine(ReloadingDelay(currentWeapon.ReloadingTime));
                IsReloading = true;
            }
        }
    }

    private IEnumerator ReloadingDelay(float reloadingTime) {
        yield return new WaitForSeconds(reloadingTime);
        {
            IsReloading = false;
            RestoreBulletsAmount();
            OnReloaded.Invoke();
        }
    }

    private void RestoreBulletsAmount() {
        _weaponChanger.CurrentGun.CurrentBulletsAmount = _weaponChanger.CurrentGun.BulletsAmount;
    }

    private void UpdateReloadingAnimationState() {
        string reloadingKey = "IsReloading";
        _weaponChanger.CurrentGun.WeaponAnimator.SetBool(reloadingKey, IsReloading);
    }
}
