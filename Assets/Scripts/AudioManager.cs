using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource BGAudioSource;
    [SerializeField] private AudioClip BGAudioClip;

    [SerializeField] private AudioSource JetAudioSource;
    [SerializeField] private AudioClip JetAudioClip;

    private AudioSource AstorideAudioSource;
    [SerializeField] private AudioClip AstorideAudioClip;

    private void OnEnable()
    {
        EventHandler.OnGameStart += BGAudioPlay;
        EventHandler.OnGameEnd += BGAudioStop;
        EventHandler.onBullateSpawn += JetAudioPlay;
        EventHandler.OnAstroidCollision += AstorideAudioPlay;
    }

    private void OnDisable()
    {
        EventHandler.OnGameStart -= BGAudioPlay;
        EventHandler.OnGameEnd -= BGAudioStop;
        EventHandler.onBullateSpawn -= JetAudioPlay;
        EventHandler.OnAstroidCollision -= AstorideAudioPlay;
    }

    private void BGAudioStop()
    {
        BGAudioSource.Stop();
        //AstorideAudioSource.Stop();
        JetAudioSource.Stop();
    }

    private void BGAudioPlay()
    {
        BGAudioSource.clip = BGAudioClip;
        BGAudioSource.Play();
    }

    private void JetAudioPlay()
    {
        JetAudioSource.clip = JetAudioClip;
        JetAudioSource.Play();
    }

    private void AstorideAudioPlay(AudioSource AstorideAudio)
    {
        AstorideAudioSource = AstorideAudio;
        AstorideAudioSource.clip = AstorideAudioClip;
        AstorideAudioSource.Play();
    }


}
