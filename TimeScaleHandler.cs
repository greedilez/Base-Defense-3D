using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleHandler : MonoBehaviour
{
    public void SetTimeScaleTo(float value) => Time.timeScale = value;
}
