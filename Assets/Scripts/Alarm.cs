using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    [SerializeField] private float _alarmSpeed;

    private float _maxVolume = 1;
    private float _minVolume = 0;

    private bool _isTriggered;

    private void Update()
    {
        if (_isTriggered)
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maxVolume, _alarmSpeed * Time.deltaTime);
        else
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _minVolume, _alarmSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FrauderMovement frauder))
            _isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FrauderMovement frauder))
            _isTriggered = false;
    }
}
