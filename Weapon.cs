using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    public float Damage, ReloadingTime, DelayBetweenShot, BulletsAmount, DelayBeforeShot, CurrentBulletsAmount;

    public Transform ShootingPosition;

    public UnityEvent OnShotWithThisWeapon, OnStartedReloading;

    public Animator WeaponAnimator{ get; private set; }

    private void Awake() {
        WeaponAnimator = GetComponent<Animator>();
    }
}
