using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Weapon")]
public class WeaponVariable : ScriptableObject
{
    public float Damage;
    public float BulletSpeed;
    public float FireRate;
    public float AmmoCount;
}
