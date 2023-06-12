using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField] private int _mouseButtonIndexToShoot = 0;

    public bool IsShooting{ get; private set; }

    public bool MadeAShot{ get; private set; }

    public bool CanShoot{ get; set; }

    public UnityEvent OnShoot;

    [SerializeField] private WeaponChanger _weaponChanger;

    [SerializeField] private ReloadHandler _reloadingHandler;

    [SerializeField] private float _weaponGettingDelay = 0.75f;

    [SerializeField] private GameObject _concreteBulletMark, _bloodBulletMark;

    [SerializeField] private Transform _camera;

    private float _raycastLength = 1000;

    private string _limitsTag = "Limits";

    public static ShootingHandler Instance;

    private void Awake() {
        Instance = this;
        ChangeCanShootStateAfterWeaponSwap(_weaponGettingDelay);
    }

    private void Update() {
        TrackForMouseButtonPress();
    }
       
    private void TrackForMouseButtonPress() {
        IsShooting = Input.GetMouseButton(_mouseButtonIndexToShoot) || Input.GetMouseButtonDown(_mouseButtonIndexToShoot);
        if (!PauseHandler.Instance.IsPaused) {
            if (!_reloadingHandler.IsReloading && PlayerDeathHandler.Instance.IsPlayerAlive) {
                if (IsShooting && CanShoot) {
                    if (!MadeAShot) {
                        StartCoroutine(DelayBeforeShot());
                        MadeAShot = true;
                    }
                }
            }
        }
    }

    private IEnumerator DelayBeforeShot() {
        yield return new WaitForSeconds(_weaponChanger.CurrentGun.DelayBeforeShot); Shoot();
    }

    private void Shoot() {
        if (_weaponChanger.CurrentGun.CurrentBulletsAmount > 0) {
            ChargeCurrentBulletsAmount();
            _weaponChanger.CurrentGun.OnShotWithThisWeapon.Invoke();
            OnShoot.Invoke();
            SendARaycast();
            StartCoroutine(BetweenShootDelay());
        }
        else ResetAllDataOnNoneAmmo();
    }

    private void ChargeCurrentBulletsAmount() {
        _weaponChanger.CurrentGun.CurrentBulletsAmount--;
    }

    public void SendARaycast() {
        RaycastHit hit;
        float yOffset = 0.01f;
        Vector3 origin = _camera.position + new Vector3(0, yOffset, 0);
        Vector3 direction = _weaponChanger.CurrentGun.transform.forward;
        Debug.DrawRay(origin, direction * _raycastLength, Color.green);
        if(Physics.Raycast(origin, direction, out hit, _raycastLength)) {
            PlaceABulletMark(hit);
            TryToDischargeZombieHealth(hit);
        }
    }

    private void TryToDischargeZombieHealth(RaycastHit hit) {
        if(hit.collider.tag == "Zombie") {
            ZombieHealthHandler zombieHealthHandler = hit.collider.GetComponent<ZombieHealthHandler>();
            zombieHealthHandler.DischargeZombieHealth(_weaponChanger.CurrentGun.Damage);
        }
    }

    public void PlaceABulletMark(RaycastHit hit) {
        if(hit.collider.tag != _limitsTag) {
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Instantiate((hit.collider.tag == "Zombie") ? _bloodBulletMark : _concreteBulletMark, hit.point + (hit.normal * 0.001f), rotation);
        }
    }

    private IEnumerator BetweenShootDelay() {
        yield return new WaitForSeconds(_weaponChanger.CurrentGun.DelayBetweenShot);
        {
            MadeAShot = false;
        }
    }

    public void ChangeCanShootStateAfterWeaponSwap(float delay) {
        CanShoot = false;
        StartCoroutine(ShootingDelayAfterWeaponSwap(delay));
    }

    private void ResetAllDataOnNoneAmmo() {
        StopAllCoroutines();
        CanShoot = true;
        MadeAShot = false;
    }

    private IEnumerator ShootingDelayAfterWeaponSwap(float delay) {
        yield return new WaitForSeconds(delay); CanShoot = true;
    }
}
