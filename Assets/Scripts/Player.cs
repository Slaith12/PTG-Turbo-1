using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Serialization;

[SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
public class Player : MonoBehaviour
{
    public Vector3 stepToTheRight;
    public Vector3 slideAngle;
    public float lerpFrac;

    private Quaternion _slideAngle;
    private Quaternion _baseAngle;

    [FormerlySerializedAs("snapToDistance")]
    public float posSnapToDistance;

    public float scaSnapToDistance;

    private Vector3 _basePosition;
    private Vector3 _baseScale;
    private Vector3[] _steps;

    private Vector3 _targetScale;

    public int currentPosition = 1;
    private Vector3 _targetVector3;
    private Quaternion _targetRotation;

    private void Start()
    {
        _slideAngle = Quaternion.Euler(slideAngle);

        _basePosition = transform.position;
        _baseScale = transform.localScale;
        _baseAngle = transform.rotation;
        _targetVector3 = _basePosition;
        _targetScale = _baseScale;
        _steps = new[] {_basePosition - stepToTheRight, _basePosition, _basePosition + stepToTheRight};
        currentPosition = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentPosition = Math.Max(0, currentPosition - 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentPosition = Math.Min(2, currentPosition + 1);
        }

        _targetRotation = Input.GetKey(KeyCode.DownArrow) ? _slideAngle : _baseAngle;

        _targetVector3 = _steps[currentPosition];

        if ((_targetVector3 - transform.position).magnitude < posSnapToDistance)
        {
            transform.position = _targetVector3;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _targetVector3, lerpFrac * Time.deltaTime);
        }

        if ((_targetScale - transform.localScale).magnitude < scaSnapToDistance)
        {
            transform.localScale = _targetScale;
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, lerpFrac * Time.deltaTime);
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, lerpFrac * Time.deltaTime);
    }
}