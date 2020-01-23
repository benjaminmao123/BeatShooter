using UnityEngine;

public class SparksParticle : MonoBehaviour
{
    private void Start()
    {
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public void Emit(Color startColor)
    {
        var main = ParticleSystem.main;
        main.startColor = startColor;
        ParticleSystem.Emit(150);
    }

    ParticleSystem ParticleSystem;
}
