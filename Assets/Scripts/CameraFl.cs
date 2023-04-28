using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFl : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 currenVelocity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPostion= target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPostion, ref currenVelocity ,smoothTime);
    }
}
