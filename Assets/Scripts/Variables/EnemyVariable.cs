using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Enemy")]
public class EnemyVariable : ScriptableObject
{
    public float Health;
    public float Score;
    public float Damage;
    public float MovementSpeed;
    public float AttackRate;
    public float BulletSpeed;
    public float DetectRange;
    public float ActionRange;
}
