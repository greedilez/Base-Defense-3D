using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _zombies;

    private int _currentZombieAmountToSpawn = 3;

    [SerializeField] private float _betweenSpawningDelay;

    private float _maximalOffset = 5;

    private void Awake() {
        StartCoroutine(ZombieSpawningRoutine());
        SpawnZombies(_currentZombieAmountToSpawn);
    }

    private IEnumerator ZombieSpawningRoutine() {
        yield return new WaitForSeconds(_betweenSpawningDelay);
        {
            SpawnZombies(_currentZombieAmountToSpawn);
            int increasingAmount = 1;
            _currentZombieAmountToSpawn += increasingAmount;
            StartCoroutine(ZombieSpawningRoutine());
        }
    }

    public void SpawnZombies(int zombiesAmount) {
        for (int i = 0; i < zombiesAmount; i++) {
            int targetZombieIndex = Random.Range(0, _zombies.Length);
            float xOffset = Random.Range(-_maximalOffset, _maximalOffset);
            float zOffset = Random.Range(-_maximalOffset, _maximalOffset);
            Vector3 offset = new Vector3(xOffset, 0, zOffset);
            Instantiate(_zombies[targetZombieIndex], transform.position + offset, Quaternion.identity);
        }
    }
}
