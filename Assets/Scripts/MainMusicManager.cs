using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMusicManager : MonoBehaviour
{
    private static MainMusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
