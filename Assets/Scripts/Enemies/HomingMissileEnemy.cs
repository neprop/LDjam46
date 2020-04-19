using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class HomingMissileEnemy : MonoBehaviour
{
    public Transform target;
    public float force;
    public float maxVelocity;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private void Awake()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        // target = target != null ? target : FindObjectOfType<Movement>().transform;
    }

    private void Start()
    {
        _rigidbody2D.AddForce(Vector2.right * force);
    }

    private void Update()
    {
        var hasTarget = target != null;
        var currentPosition = transform.position;
        var targetPosition = hasTarget
            ? target.position
            : _startPosition;
        var vector = targetPosition - currentPosition;

        var f = force;
        vector.Normalize();
        _rigidbody2D.MoveRotation(Mathf.Lerp(_rigidbody2D.rotation, Vector2.SignedAngle(Vector2.up, vector), 0.1f));
        _rigidbody2D.AddForce(vector * f);
        var currentSqrVelocity = _rigidbody2D.velocity.sqrMagnitude;

        var mv = maxVelocity;
        if (mv * mv < currentSqrVelocity)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * mv;
        }
    }
}
