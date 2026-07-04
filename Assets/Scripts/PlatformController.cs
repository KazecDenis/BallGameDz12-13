using UnityEngine;

public class PlatformController : MonoBehaviour
{
   [SerializeField] private Vector3 _deadZoneMin;
   [SerializeField] private Vector3 _deadZoneMax; 
   [SerializeField] private float _rotateSpeed;
   private Rigidbody rigidbody;
    private const string _zKeyAxis = "Horizontal";
    private const string _xKeyAxis = "Vertical";
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        RotatePlane();
    }

    private void RotatePlane()
    {
        float zInput = Input.GetAxis(_zKeyAxis) * _rotateSpeed;
        float xInput = Input.GetAxis(_xKeyAxis) * _rotateSpeed;
        Vector3 Rotation = new Vector3(xInput, 0f, zInput);
        Quaternion rotation = Quaternion.Euler(Rotation);

        rigidbody.MoveRotation(rotation);
    }
}


