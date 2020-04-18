using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class HomingMissileEnemy : MonoBehaviour
{
    public Transform target;
    public float force;
    public float maxVelocity;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        // target = target != null ? target : FindObjectOfType<Movement>().transform;
    }

    private void Update()
    {
        if (target == null) return;

        var vector = target.position - transform.position;
        vector.Normalize();
        _rigidbody2D.AddForce(vector * force);
        var currentSqrVelocity = _rigidbody2D.velocity.sqrMagnitude;
        if (maxVelocity * maxVelocity < currentSqrVelocity)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * maxVelocity;
        }
    }
}
