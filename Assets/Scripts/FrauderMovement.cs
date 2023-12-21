using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrauderMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Collision2D _wall;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = (new Vector2(
            Input.GetAxis("Horizontal") * Time.deltaTime,
            Input.GetAxis("Vertical") * Time.deltaTime).normalized) * _moveSpeed;

        if (_wall != null)
        {
            float projection = Vector2.Dot(_rigidbody.velocity, _wall.contacts[0].normal);

            if (projection < 0)
                _rigidbody.velocity -= projection * _wall.contacts[0].normal;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _wall = collision;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _wall = null;   
    }
}
