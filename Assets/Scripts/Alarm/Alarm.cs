using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AlarmTrigger))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    [SerializeField] private float _alarmSpeed;

    private float _maxVolume = 1;
    private float _minVolume = 0;

    private AlarmTrigger _trigger;
    private bool _isAlarmEnable;

    private void Awake()
    {
        _trigger = GetComponent<AlarmTrigger>();
    }

    private void OnEnable()
    {
        _trigger.Triggered += OnTriggerd;
    }

    private void OnDisable()
    {
        _trigger.Triggered -= OnTriggerd;
    }

    private void OnTriggerd(bool isTriggered)
    {
        _isAlarmEnable = isTriggered;
        StartCoroutine(ChangeAlarmValue());
    }

    private IEnumerator ChangeAlarmValue()
    {
        float endValue = _isAlarmEnable ? _maxVolume : _minVolume;
        bool isAlarmEnable = _isAlarmEnable;

        while (isAlarmEnable == _isAlarmEnable && _alarm.volume != endValue)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, endValue, _alarmSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
