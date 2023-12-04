using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource soundSource;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object even when we go to new scene
        }
        else if (Instance != null && Instance != this) // Destroy duplicate gameobjects
            Destroy(gameObject);
    }

    public void PlaySound(AudioClip _sound) => soundSource.PlayOneShot(_sound);
}
