using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"GameOverTrigger.OnCollisionEnter2D other.gameObject={other.gameObject.name}");
        var isPlayer = other.gameObject.GetComponent<Movement>() != null;
        if (isPlayer)
        {
            Debug.LogError("GameOver");
        }
    }
}
