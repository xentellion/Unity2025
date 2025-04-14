using DG.Tweening;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private int _count = 0;
    [SerializeField] private Transform _target;
    [SerializeField] private Ease _ease;
    [SerializeField] private Ease _easeRotate;

    public void StartThings(int times)
    {
        _count += times;
        Debug.Log($"Button pressed {_count} times");

        _target.DOLocalMove(new Vector3(200, 0, 0), 2)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(_ease);
        _target.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(_easeRotate);
    }
}
