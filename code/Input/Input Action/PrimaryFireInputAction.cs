using UnityEngine;

public class PrimaryFireInputAction : MonoBehaviour, IInputAction
{ 
    void Start()
    {
        Laser = FindObjectOfType<Laser>();
    }

    public void Execute()
    {
        if (Laser.Hit.collider)
        {
            ColorChanger colorChanger = Laser.Hit.collider.GetComponent<ColorChanger>();

            if (colorChanger)
            {
                SparksParticle sparksParticle = Laser.Hit.collider.GetComponent<SparksParticle>();

                if (colorChanger.enabled)
                {
                    if (colorChanger.Index == GameManager.Instance.CurrentIndex)
                    {
                        if (colorChanger.Renderer.material.color.b >= colorChanger.Renderer.material.color.r)
                        {
                            GameEvents.HitGood();
                        }
                        else if (colorChanger.Renderer.material.color.b < colorChanger.Renderer.material.color.r)
                        {
                            GameEvents.HitBad();
                        }

                        ++GameManager.Instance.CurrentIndex;
                        sparksParticle.Emit(colorChanger.Renderer.material.color);
                        colorChanger.enabled = false;
                    }
                }
            }
        }
    }

    Laser Laser;
}
