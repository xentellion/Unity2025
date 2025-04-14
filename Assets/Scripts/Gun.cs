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

    private int _bulletCount = 0;
     

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
            _autoFire = !context.canceled;
        }
    }

    IEnumerator ShootBullet()
    {
        _bulletCount++;
        ShowBullet.OnAmmoChange.Invoke(_bulletCount);
        _onCoolDown = true;
        if (!_hitscan)
        {
            Instantiate(_bullet, _muzzle.position, transform.parent.rotation); 
        }
        else
        {
            Physics.Raycast(_muzzle.transform.position, _muzzle.transform.forward, out RaycastHit hit);
            if (hit.collider.CompareTag("Destructable"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
        yield return new WaitForSeconds(0.5f);
        _onCoolDown = false;
    }
}
