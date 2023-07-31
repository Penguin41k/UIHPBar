using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Bar : MonoBehaviour
{
    [SerializeField] private float _valueChangeSpeed;
    [SerializeField] private Player _player ;

    private Slider _barSlider;

    private Coroutine _changeValueJob;

    private void OnEnable()
    {
        _player.HPChanged += StartChangeBarValue;
    }

    private void OnDisable()
    {
        _player.HPChanged -= StartChangeBarValue;
    }

    private void Start()
    {
        _barSlider = GetComponent<Slider>();
    }

    public void StartChangeBarValue(int value, int maxValue)
    {
        float targetValue=(float)value/maxValue;

        if (_changeValueJob != null)
        {
            StopCoroutine(_changeValueJob);
        }

        _changeValueJob = StartCoroutine(ChangeBarValue(targetValue));
    }

    private IEnumerator ChangeBarValue(float targetValue)
    {
        while (_barSlider.value != targetValue)
        {
            _barSlider.value = Mathf.MoveTowards(_barSlider.value, targetValue, _valueChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
