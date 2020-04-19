using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject root;

    private bool _isPause = true;

    public void PauseGame()
    {
        Time.timeScale = 0;
        root.SetActive(true);
        _isPause = true;
    }

    public void ResumeGame()
    {
        root.SetActive(false);
        Time.timeScale = 1;
        _isPause = false;
    }

    private void Awake()
    {
        ResumeGame();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (_isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
