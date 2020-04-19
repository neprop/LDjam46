using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"GameOverTrigger.OnCollisionEnter2D other.gameObject={other.gameObject.name}");
        var isPlayer = other.gameObject.GetComponent<Movement>() != null;
        if (isPlayer)
        {
            var activeScene = SceneManager.GetActiveScene();
            Debug.Log($"Game Over. Restarting scene '{activeScene.name}'");
            SceneManager.LoadScene(activeScene.name);
        }
    }
}
