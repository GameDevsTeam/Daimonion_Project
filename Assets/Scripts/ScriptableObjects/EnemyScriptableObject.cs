using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject that holds the BASE STATS for an enemy. These can then be modified at object creation time to buff up enemies and to reset their stats if they died or were modified at runtime.
/// </summary>
/// 

[CreateAssetMenu(fileName ="Enemy configuration", menuName ="ScriptableObject/Enemy Configuration")]

public class EnemyScriptableObject : ScriptableObject
{
    // Enemy Stats
    public int Health = 100;

    // Enemy Sprite
    public Sprite sprite;


}
