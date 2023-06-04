using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
public class Obstacle : MonoBehaviour
{
    // pretend like its the train from Subway Surfers
    public static float Speed = 20f;
    private static readonly Vector3 Motion = new Vector3(-1, 0, 0);
    
    private void Start()
    {
        var position = transform.position;
        position.x = 200;
        transform.position = position;
    }

    private void Update()
    {
        transform.position += Motion * (Speed * Time.deltaTime);
    }
}