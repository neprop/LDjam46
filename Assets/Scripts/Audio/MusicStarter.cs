using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public AudioClip audioClip;

    public void Start()
    {
        MusicPlayer.Instance.PlayMusic(audioClip);
    }
}