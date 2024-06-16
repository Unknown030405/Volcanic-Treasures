using System;
using System.Collections;
using TMPro;
using UnityEngine;
 
[RequireComponent(typeof(TMP_Text))]
public class CountAnimation : MonoBehaviour
{
    public float countDuration = Fields.CountAnimationDuration;
    private TMP_Text _numberText;
    private float _currentValue;
    private float _targetValue;
    private Coroutine _coroutine;
 
    private void Awake() => _numberText = GetComponent<TMP_Text>();
 
    private void Start()
    {
        _currentValue = float.Parse(_numberText.text);
        _targetValue = _currentValue;
    }
 
    private IEnumerator CountTo(float targetValue)
    {
        var rate = Mathf.Abs(targetValue - _currentValue) / countDuration;
        while(Math.Abs(_currentValue - targetValue) > float.Epsilon)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, targetValue, rate * Time.deltaTime);
            _numberText.text = ((int)_currentValue).ToString();
            yield return null;
        }
    }
 
    public void SetTarget(float target)
    {
        _targetValue = target;
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(CountTo(_targetValue));
    }
}