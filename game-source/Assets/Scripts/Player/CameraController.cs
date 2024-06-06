using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Camera following Player script
    
    private Vector3 _offset;

    [SerializeField] private Transform target;

    [SerializeField] private float smoothTime;

    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 tgtp = target.position;
        Vector3 targetPosition = new Vector3(tgtp.x, tgtp.y, 0)  + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
