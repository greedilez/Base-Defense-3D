using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestRecordHandler : MonoBehaviour
{
    private const string _bestRecordPlayerPrefsKey = "BestRecord";

    [SerializeField] private KilledZombiesAmount _killedZombiesAmount;

    [SerializeField] private TMP_Text _recordText;

    private void Awake() {
        TryToLoadRecordIntoText();
    }

    private void TryToLoadRecordIntoText() {
        if(_recordText != null) {
            _recordText.text = $"Рекорд: {PlayerPrefs.GetInt(_bestRecordPlayerPrefsKey, 0)}";
        }
    }

    public void TryToSaveNewRecord() {
        int lastSavedKilledAmount = PlayerPrefs.GetInt(_bestRecordPlayerPrefsKey, 0);
        int currentKilledAmount = _killedZombiesAmount.CurrentZombieKilledAmount;
        if (currentKilledAmount > lastSavedKilledAmount) {
            PlayerPrefs.SetInt(_bestRecordPlayerPrefsKey, currentKilledAmount);
        }
    }
}
