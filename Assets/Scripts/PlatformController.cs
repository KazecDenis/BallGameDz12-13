using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlatformController : MonoBehaviour
{
   [SerializeField] private Vector3 _deadZoneMin;
   [SerializeField] private Vector3 _deadZoneMax; 
   [SerializeField] private float _rotateSpeed;
    private const string _zKeyAxis = "Horizontal";
    private const string _xKeyAxis = "Vertical";
    private float _minNum = 0.05f;
    private void Update()
    {
        RotatePlane();
    }

    private void RotatePlane()
    {
        Vector3 center = new Vector3(transform.position.x, 0, transform.position.z);
        float zInput = Input.GetAxis(_zKeyAxis) * _rotateSpeed;
        float xInput = Input.GetAxis(_xKeyAxis) * _rotateSpeed;
        Vector3 axisBack = Vector3.back;
        Vector3 axisForward = Vector3.right;
        float angleZ = zInput * Time.deltaTime;
        float angleX = xInput * Time.deltaTime;

        angleZ = Mathf.Clamp(angleZ, _deadZoneMin.z, _deadZoneMax.z);
        angleX = Mathf.Clamp(angleX, _deadZoneMin.x, _deadZoneMax.x);


        transform.RotateAround(center, axisForward, angleX);
        transform.RotateAround(center, axisBack, angleZ);
    }
}


