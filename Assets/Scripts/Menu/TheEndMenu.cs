using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEndMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
