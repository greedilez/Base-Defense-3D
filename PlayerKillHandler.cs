using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKillHandler : MonoBehaviour
{
    public UnityEvent OnPlayerCatch;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            TriggerPlayerDeath(other);
            OnPlayerCatch.Invoke();
        }
    }

    private void TriggerPlayerDeath(Collider playerCollider) {
        PlayerDeathHandler playerDeathHandler = playerCollider.GetComponent<PlayerDeathHandler>();
        playerDeathHandler.PlayerDeath();
        RotatePlayerAtZombie(playerCollider);
    }

    private void RotatePlayerAtZombie(Collider playerCollider) => playerCollider.gameObject.transform.LookAt(transform.position);
}
