using UnityEngine;

public class EnemyActivationTrigger : MonoBehaviour
{
    public HomingMissileEnemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"GameOverTrigger.OnCollisionEnter2D other.gameObject={other.gameObject.name}");
        var isPlayer = other.gameObject.GetComponent<Movement>() != null;
        if (isPlayer)
        {
            enemy.target = other.transform;
            this.enabled = false;
        }
    }
}
