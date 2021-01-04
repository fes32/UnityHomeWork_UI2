using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Button _upHealthButton;
    [SerializeField] private Button _downHealthButton;
    [SerializeField] private float _stepChangeHealth;
    [SerializeField] private float _speed;

    private Slider _healthDisplay;

    private void Start()
    {
        _healthDisplay = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _upHealthButton.onClick.AddListener(OnUpHealthButtonClick);
        _downHealthButton.onClick.AddListener(OnDownHealthButtonClick);
    }

    private void OnDisable()
    {
        _upHealthButton.onClick.RemoveListener(OnUpHealthButtonClick);
        _downHealthButton.onClick.RemoveListener(OnDownHealthButtonClick);
    }

    private void OnUpHealthButtonClick()
    {
        if (_healthDisplay.value < _healthDisplay.maxValue)
        {
            float totalHealth = _healthDisplay.value + _stepChangeHealth;
           StartCoroutine(ChangeHealth(totalHealth));
        }
    }

    private void OnDownHealthButtonClick()
    {
        if (_healthDisplay.value > _healthDisplay.minValue)
        {
            float totalHealth = _healthDisplay.value - _stepChangeHealth;
            StartCoroutine(ChangeHealth(totalHealth));
        }
    }

    private IEnumerator ChangeHealth(float totalHealth)
    {
        while(_healthDisplay.value!=totalHealth)
        {
            _healthDisplay.value = Mathf.MoveTowards(_healthDisplay.value, totalHealth, _speed);

            yield return null;
        }
    }
}