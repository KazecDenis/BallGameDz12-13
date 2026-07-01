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

    private bool isJumping;
    private bool _isOnGround;

    public int DiamondCount() => _diamond;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        isJumping = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isJumping = true;
    }

    private void FixedUpdate()
    {
        if(isJumping && _isOnGround)
            Jump();
        else
            Move();
    }


    private void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
        isJumping = false;
    }

    private void Move()
    {
        if (_isOnGround)
        {
        float horizontalInput = Input.GetAxis(_horizontalKeyAxis);
        float verticalInput = Input.GetAxis(_verticalKeyAxis);

        Vector3 force = new Vector3(horizontalInput * _speed, 0, verticalInput * _speed);

        _rigidbody.AddForce(force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _plane = collision.collider.GetComponent<Collider>();
            
            if(_plane != null)
        {
            isJumping = false;
            _isOnGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        _plane = collision.collider.GetComponent<Collider>();
            
            if(_plane != null)
        {
            isJumping = false;
            _isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _plane = collision.collider.GetComponent<Collider>();

        if (_plane != null)
        {
            isJumping = true;
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
            
