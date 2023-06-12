using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMarkSelfDestroyer : MonoBehaviour
{
    private float _destroyMarkAfterSeconds = 5;

    private void Awake() {
        Destroy(gameObject, _destroyMarkAfterSeconds);
    }
}
