using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KilledZombiesAmount : MonoBehaviour
{
    public int CurrentZombieKilledAmount{ get; private set; }

    public UnityEvent OnZombieKilled;

    public static KilledZombiesAmount Instance;

    [SerializeField] private TMP_Text _currentZombieKilledAmountText;

    private void Awake() => Instance = this;

    public void IncreasKilledZombieAmountBy(int value) {
        CurrentZombieKilledAmount += value;
        UpdateText();
    }

    private void UpdateText() => _currentZombieKilledAmountText.text = $"Зомби убито: {CurrentZombieKilledAmount}";
}
