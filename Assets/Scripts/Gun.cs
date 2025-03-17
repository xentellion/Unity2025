using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzle;
    [SerializeField]
    private GameObject _bullet;


    private void Update()
    {
        // менорхлюкэмн
        if (Input.GetMouseButton(0))
        {
            Instantiate(_bullet, _muzzle.position, transform.parent.rotation, transform);
        } 
    }
}
