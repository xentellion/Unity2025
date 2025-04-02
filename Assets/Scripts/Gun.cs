using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzle;
    [SerializeField]
    private GameObject _bullet;
    [Space(5)]
    [SerializeField]
    private bool _semiauto;
    [SerializeField]
    private bool _hitscan = true;

    private bool _autoFire = false;
    private bool _onCoolDown = false;
     

    private void Start()
    {
        Player.instance.Shooting.AddListener(Shoot);
    }

    private void Update()
    {
        if (_autoFire && !_onCoolDown)
        {
            StartCoroutine(ShootBullet());
        }
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (_semiauto)
        {
            if (context.started && !_onCoolDown)
            {
                StartCoroutine(ShootBullet());
            }
        }
        else
        {
            if (context.started) 
            { 
                _autoFire = true;
            }
            else if (context.canceled)
            {
                _autoFire = false;
            }
        }
    }

    IEnumerator ShootBullet()
    {
        if (!_hitscan)
        {
            Instantiate(_bullet, _muzzle.position, transform.parent.rotation);
            _onCoolDown = true;
            yield return new WaitForSeconds(0.5f);
            _onCoolDown = false;
        }
        else
        {
            Physics.Raycast(_muzzle.transform.position, _muzzle.transform.forward, out RaycastHit hit);
            if (hit.collider.CompareTag("Destructable"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
