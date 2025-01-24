using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] Transform _endAnchor;
    [SerializeField] Renderer _renderer;
    public Vector3 EndAnchorPosition => _endAnchor.position;
    public Color Color { get => _renderer.material.color; set => _renderer.material.color = value; }
}
