using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointUpdate : MonoBehaviour
{
    private int _pointCount;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        EatFood.instance += PointTextUpdate;
    }
    private void Start()
    {
        _pointCount = 0;
        
        PointTextUpdate();
    }

    private void PointTextUpdate()
    {
        _text.text = $"Очков: {_pointCount++}";
    }

    private void OnDisable()
    {
        EatFood.instance -= PointTextUpdate;
    }
}
