using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WaveData", menuName ="ScriptableObjects/WaveData")]
public class WaveData : ScriptableObject
{
    public GameObject[] enemies;
    public float duration;
}
