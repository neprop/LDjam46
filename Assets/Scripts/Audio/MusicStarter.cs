using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicStarter : MonoBehaviour
{
    public static MusicStarter instance;

    public AudioClip audioClip;
    public AudioFx audioFx;

    public void OneShot(AudioClip[] audioClips)
    {
        var index = Random.Range(0, audioClips.Length);
        var clip = audioClips[index];
        MusicPlayer.Instance.OneShot(clip);
    }

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        MusicPlayer.Instance.PlayMusic(audioClip);
    }

    [Serializable]
    public struct AudioFx
    {
        public AudioClip[] death;
        public AudioClip[] jump;
        public AudioClip[] step;
        public AudioClip[] win;
    }
}