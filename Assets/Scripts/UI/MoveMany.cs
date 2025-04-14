using UnityEngine;
using DG.Tweening;

public class MoveMany : MonoBehaviour
{
    [SerializeField]
    private Transform[] _tiles;

    private float _n = 0;

    private void Awake()
    {
        DOVirtual.Float(0, 10, 2f, x => 
        { 
            _n = x;
        }).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        Debug.Log(_n);
    }


    private void Start()
    {
        var sequence = DOTween.Sequence();

        foreach (var tile in _tiles)
        {
            sequence.Append(tile.DOMoveX(1900, 2f));
        }

        sequence.OnComplete(() => 
        {
            foreach (var tile in _tiles)
            {
                tile.DOScale(Vector3.zero, 2f)
                .SetEase(Ease.InBounce);
            }
        });
    }
}
