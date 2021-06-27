using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource musicAud;

    private static bool isSoundEnabled, isMusicEnabled;
    
    void Start()
    {
        musicAud = GetComponent<AudioSource>();    
    }

    public void SetSoundState()
    {
        isSoundEnabled = !isSoundEnabled;

        //return sprite
    }

    public void SetMusicState()
    {
        isMusicEnabled = !isMusicEnabled;
        musicAud.mute = isMusicEnabled;
        //return sprite
    }
}