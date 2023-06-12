using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentBulletsAmountTextHandler : MonoBehaviour
{
    [SerializeField] private WeaponChanger _weaponChanger;

    [SerializeField] private TMP_Text _currentBulletsAmountText;

    private void FixedUpdate() => UpdateCurrentBulletsAmountText();

    private void UpdateCurrentBulletsAmountText() => _currentBulletsAmountText.text = $"{_weaponChanger.CurrentGun.CurrentBulletsAmount}/{_weaponChanger.CurrentGun.BulletsAmount}";
}
