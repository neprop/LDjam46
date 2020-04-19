using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"GameOverTrigger.OnCollisionEnter2D other.gameObject={other.gameObject.name}");
        var isPlayer = other.gameObject.GetComponent<Movement>() != null;
        if (isPlayer)
        {
            var activeScene = SceneManager.GetActiveScene();
            Debug.Log($"Level#{activeScene.buildIndex} complete. Trying to load next scene. (Count={SceneManager.sceneCountInBuildSettings})");
            SceneManager.LoadScene(activeScene.buildIndex + 1);

            MusicStarter.instance.OneShot(MusicStarter.instance.audioFx.win);
        }
    }
}
