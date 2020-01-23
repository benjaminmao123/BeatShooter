using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static void SongStart()
    {
        OnSongStart?.Invoke();
    }

    public static void HitGood()
    {
        OnHitGood?.Invoke();
    }

    public static void HitBad()
    {
        OnHitBad?.Invoke();
    }

    public static void HitMiss(GameObject gameObject)
    {
        OnHitMiss?.Invoke(gameObject);
    }

    public static void Death()
    {
        OnDeath?.Invoke();
    }

    public delegate void SongStartEventHandler();
    public static event SongStartEventHandler OnSongStart;
    public delegate void HitGoodEventHandler();
    public static event HitGoodEventHandler OnHitGood;
    public delegate void HitBadEventHandler();
    public static event HitBadEventHandler OnHitBad;
    public delegate void HitMissEventHandler(GameObject gameObject);
    public static event HitMissEventHandler OnHitMiss;
    public delegate void DeathEventHandler();
    public static event DeathEventHandler OnDeath;
}
