using UnityEngine;

public class Target : MonoBehaviour
{
    Renderer _renderer;

    void Awake()
    { 
        _renderer = GetComponent<Renderer>();
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }
}
