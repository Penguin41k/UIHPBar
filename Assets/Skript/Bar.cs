using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Slider))]
public class Bar : MonoBehaviour
{
    [SerializeField] private Player statusController;
    [SerializeField] private float _valueChangeSpeed;
    private Slider _barSlider;
    private int _targetBarValue;
    private Coroutine _changeValueJob;

    void Start()
    {
        _barSlider = GetComponent<Slider>();
        _barSlider.maxValue = statusController.MaxHP;
        _barSlider.value = statusController.MaxHP;
        _targetBarValue = statusController.MaxHP;
    }

    void Update()
    {
        if (_targetBarValue != statusController.CurrentHP)
        {
            _targetBarValue = statusController.CurrentHP;
            StartChangeHPBarVolum(_targetBarValue);
        }
    }

    private void StartChangeHPBarVolum(int targetValum)
    {
        if (_changeValueJob != null)
        {
            StopCoroutine(_changeValueJob); 
        }

        _changeValueJob = StartCoroutine(ÑhangeHPBarValum(targetValum));
    }


    private IEnumerator ÑhangeHPBarValum(int targetValum)
    {
        while (_barSlider.value != targetValum)
        {
            _barSlider.value = Mathf.MoveTowards(_barSlider.value, targetValum, _valueChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }


}
