using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> 
{
    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = (T)this;
        }
    }

    public static T Instance;
}
