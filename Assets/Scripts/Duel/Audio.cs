using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clip -----------")]
    public AudioClip Background;
    public AudioClip DrawCard;
    public AudioClip SelectCard;

    private void Start()
    {
        MusicSource.clip = Background;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

