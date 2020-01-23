using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        OriginalColor = Renderer.material.color;
        Light = GetComponentInChildren<Light>();
        Outline = GetComponent<Outline>();
        StartColor = Color.red;
        EndColor = Color.blue;
    }
    void Start()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        StartTime = Time.time;
        Renderer.material.color = OriginalColor;
        Light.enabled = true;
    }

    private void OnDisable()
    {
        Outline.OutlineColor = Color.clear;
        Renderer.material.color = OriginalColor;
        Light.enabled = false;
        enabled = false;
    }

    void Update()
    {
        if (Index == GameManager.Instance.CurrentIndex)
        {
            Outline.OutlineColor = Color.green;
        }

        float t = (Time.time - StartTime) * SettingsManager.Instance.Settings.Speed;

        Renderer.material.color = Color.Lerp(StartColor, EndColor, t);

        if (Renderer.material.color == Color.blue)
        {
            GameEvents.HitMiss(gameObject);
            enabled = false;
        }
    }

    float StartTime;
    public Renderer Renderer;
    Color OriginalColor;
    Color StartColor;
    Color EndColor;
    [SerializeField] Light Light;
    public int Index;
    Outline Outline;
}
