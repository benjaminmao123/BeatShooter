using UnityEngine;

public class ColorChangerTest : MonoBehaviour
{ 
    void Start()
    {
        StartTime = Time.time;
        Renderer = GetComponent<Renderer>();
        OriginalColor = Renderer.material.color;
        Renderer.material.color = Color.red;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Renderer.material.color = OriginalColor;
            StartTime = Time.time;
            IsBlue = false;
        }

        if (Renderer.material.color == Color.blue && !IsBlue)
        {
            Debug.Log(Time.time - StartTime);
            IsBlue = true;
        }

        float t = (Time.time - StartTime) * Speed;

        Renderer.material.color = Color.Lerp(Color.red, Color.blue, t);
    }

    [SerializeField] float Speed;
    float StartTime;
    Renderer Renderer;
    bool IsBlue;
    Color OriginalColor;
}
