using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private float _speed = 10;
    [SerializeField] private float _jumpSpeed = 10;

    private Vector3 _direction = Vector3.zero;
    private Vector3 _cameraDirectionn = Vector3.zero;   

    private Collider _cd;
    private Rigidbody _rb;
    private Camera _camera;

    public UnityEvent<InputAction.CallbackContext> Shooting;

    private void Awake()
    {
        // Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        _cd = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _cameraDirectionn = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (IsGrounded())
            {
                _rb.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
            } 
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        Shooting.Invoke(context);
    }

    private void Move()
    {
        var forward = _camera.transform.forward;
        var right = _camera.transform.right;

        var x_move = _direction.x * right;
        var y_move = _direction.y * forward;

        var velocity = (x_move + y_move) * _speed;
        _rb.linearVelocity = new Vector3(
            velocity.x,
            _rb.linearVelocity.y,
            velocity.z
            );
    }

    private void Look()
    {
        transform.Rotate(0, _cameraDirectionn.x, 0);
        _camera.transform.Rotate(-_cameraDirectionn.y, 0, 0);
    }

    private bool IsGrounded()
    {
        var spherePos = transform.position - new Vector3(0, _cd.bounds.size.x / 2 + 0.1f, 0);
        var touchGround = Physics.OverlapSphere(spherePos, .5f, LayerMask.GetMask("Ground"));
        return touchGround.Length > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        var spherePos = transform.position - new Vector3(0, 0.6f, 0);
        Gizmos.DrawWireSphere(spherePos, .5f);
    }
}
