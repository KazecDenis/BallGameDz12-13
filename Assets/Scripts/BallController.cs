using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    private const string _horizontalKeyAxis = "Horizontal";
    private const string _verticalKeyAxis = "Vertical";
    private Rigidbody _rigidbody;

    private int _diamond = 0;
    [SerializeField] private Collider _plane;

    private float _horizontalInput;
    private float _verticalInput;

    private bool _isJumping;
    private bool _isOnGround;

    public int DiamondCount() => _diamond;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isJumping = false;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis(_horizontalKeyAxis);
        _verticalInput = Input.GetAxis(_verticalKeyAxis);

        if (Input.GetKeyDown(KeyCode.Space))
            _isJumping = true;
    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(_horizontalInput * _speed, 0, _verticalInput * _speed);

        Move(force);

        if(_isJumping && _isOnGround)
            Jump();
    }


    private void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
        _isJumping = false;
    }

    private void Move(Vector3 force)
    {
        if (_isOnGround)
            _rigidbody.AddForce(force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _plane = collision.collider.GetComponent<Collider>();
            
            if(_plane != null)
        {
            _isJumping = false;
            _isOnGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        _plane = collision.collider.GetComponent<Collider>();
            
        if(_plane != null)
        {
            _isJumping = false;
            _isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _plane = collision.collider.GetComponent<Collider>();

        if (_plane != null)
        {
            _isOnGround = false;
        }
    }

    public void ResetPosition(Transform target) => transform.position = target.position;

    public int ResetDiamond() => _diamond = 0;
    public void TakeDiamond(int reward)
    {
        _diamond += reward;
        Debug.Log(DiamondCount());
    }
}
            
