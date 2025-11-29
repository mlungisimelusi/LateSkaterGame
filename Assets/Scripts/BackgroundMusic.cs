using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource musicSource;

    void Awake()
    {
        // Ensure the GameObject persists between scenes
       // DontDestroyOnLoad(gameObject);

        // Get the AudioSource component attached to this GameObject
        musicSource = GetComponent<AudioSource>();
    }

    public void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void PlayMusic()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}