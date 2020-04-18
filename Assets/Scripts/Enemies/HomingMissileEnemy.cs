using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class HomingMissileEnemy : MonoBehaviour
{
    public Transform target;
    public float force;
    public float maxVelocity;
    public float calmForce;
    public float calmMaxVelocity;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private void Awake()
    {
        _startPosition = transform.localPosition;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        // target = target != null ? target : FindObjectOfType<Movement>().transform;
    }

    private void Start()
    {
        _rigidbody2D.AddForce(Vector2.right * calmForce);
    }

    private void Update()
    {
        var hasTarget = target != null;
        var vector = hasTarget
            ? target.position - transform.position
            : _startPosition - transform.localPosition;

        var f = hasTarget ? force : calmForce;
        vector.Normalize();
        _rigidbody2D.AddForce(vector * f);
        var currentSqrVelocity = _rigidbody2D.velocity.sqrMagnitude;

        var mv = hasTarget ? maxVelocity : calmMaxVelocity;
        if (mv * mv < currentSqrVelocity)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * mv;
        }
    }
}
