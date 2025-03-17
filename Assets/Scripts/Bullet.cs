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
        // менорхлюкэмн
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet == null)
        {
            Destroy(gameObject);
            Debug.Log("Bullet destroyed");
        }
    }
}
