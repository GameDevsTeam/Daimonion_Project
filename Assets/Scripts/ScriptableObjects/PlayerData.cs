using UnityEngine;

/// <summary>
/// ScriptableObject that holds the BASE STATS for an enemy. These can then be modified at object creation time to buff up enemies and to reset their stats if they died or were modified at runtime.
/// </summary>
/// 

[CreateAssetMenu(fileName = "Player configuration", menuName = "ScriptableObject/Player Configuration")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public GameObject playerModel;
    public int health;
    public int attackDamage;
    public int defenseRate;
}
