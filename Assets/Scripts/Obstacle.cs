using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // pretend like its the train from Subway Surfers
    public static float Speed = 20f;
    private static readonly Vector3 Motion = new Vector3(-1, 0, 0);
    [SerializeField] float despawnX = -10;

    private void Start()
    {
        var position = transform.position;
        position.x = 200;
        transform.position = position;
    }

    private void Update()
    {
        transform.position += Motion * (Speed * Time.deltaTime);
        if (transform.position.x < despawnX)
            Destroy(gameObject);
    }
}