using UnityEngine;

[RequireComponent (typeof(Rigidbody))] 
public class Bobot : MonoBehaviour
{
    [SerializeField] private GameObject[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private int _index = -1;

    private Rigidbody _rb;
    private Animator _anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        ChangeDirection();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _points[_index].transform.position) < 1e-1)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _rb.linearVelocity = Vector3.zero;
        _anim.SetBool("isWalking", false);
        _index += 1;
        _index %= _points.Length;
    }

    private void Move()
    {
        _anim.SetBool("isWalking", true);
        transform.LookAt(_points[_index].transform);
        _rb.linearVelocity = transform.forward * _speed;
    }
}
