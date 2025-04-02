using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    private Quaternion _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.linearVelocity = transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
