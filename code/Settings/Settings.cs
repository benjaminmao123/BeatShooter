using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "Settings")]
public class Settings : ScriptableObject
{
    public float Speed;
    public int GoodHitScoreValue;
    public int BadHitScoreValue;
    public float StartDelay;
    public float EndDelay;
    public int MissDamage;
    public int Health;
}
