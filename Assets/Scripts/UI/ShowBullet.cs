using UnityEngine;
using UnityEngine.Events;

public class ShowBullet : MonoBehaviour
{
    private TMPro.TMP_Text _text;
    public static UnityEvent<int> OnAmmoChange = new();

    private void Awake()
    {
        _text = GetComponentInChildren<TMPro.TMP_Text>();
    }


    private void Start()
    {
        OnAmmoChange.AddListener(ChangeText);
    }

    private void ChangeText(int count)
    {
        _text.text = count.ToString();
    }
}
