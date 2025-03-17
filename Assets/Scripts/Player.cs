using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private Vector3 _direction;

    private Collider _cd;
    private Rigidbody _rb;
    private Camera _camera;

    public static Player instance;

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
        GetMove();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void RotatePlayer()
    {
        // менорхлюкэмн
        var h = Input.GetAxis("Mouse X") * _speed;
        var v = Input.GetAxis("Mouse Y") * _speed;
        transform.Rotate(0, h, 0);
        _camera.transform.Rotate(-v, 0, 0);
    }

    private void GetMove()
    {
        // менорхлюкэмн
        var x = Input.GetAxis("Horizontal") * _camera.transform.right;
        var y = Input.GetAxis("Vertical") * _camera.transform.forward;

        _direction = (x + y).normalized * _speed;
    }

    private void Move()
    {
        // окнуюъ сопюбкъелнярэ
        _rb.AddForce(_direction, ForceMode.Force);
    }
}
