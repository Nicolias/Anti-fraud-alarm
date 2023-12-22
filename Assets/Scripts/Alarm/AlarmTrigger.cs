using UnityEngine;
using UnityEngine.Events;

public class AlarmTrigger : MonoBehaviour
{
    public event UnityAction<bool> Triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FrauderMovement frauder))
            Triggered?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FrauderMovement frauder))
            Triggered?.Invoke(false);
    }
}