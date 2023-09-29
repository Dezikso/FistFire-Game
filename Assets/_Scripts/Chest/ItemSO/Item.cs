using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="ScriptableObjects/Item")]
public class Item : PlayerStats
{
    public Sprite sprite;
    public new string name;
    public string description;

}
