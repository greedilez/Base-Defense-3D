using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVFXTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _weaponVFXs;

    [SerializeField] private WeaponChanger _weaponChanger;

    public void TriggerCurrentWeaponVFX() => _weaponVFXs[_weaponChanger.CurrentWeaponIndex].Play(true);
}
