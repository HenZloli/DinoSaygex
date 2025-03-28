using UnityEngine;

public class AudioManeger : MonoBehaviour
{
    public static AudioManeger instance;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip tapClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip crackEggClip;
    private bool phat_effect = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public bool Phat_nhac()
    {
        return phat_effect;
    }
    public void set_phat_effect(bool value)
    {
        phat_effect = value;
    }

    void Start()
    {
        effectSource.Stop();
        phat_effect = true;
    }

    
    public void SoundJump()
    {
        effectSource.PlayOneShot(jumpClip);
    }
    public void SoundTap()
    {
        effectSource.PlayOneShot(tapClip);
    }
    public void SoundHurt()
    {
        effectSource.PlayOneShot(hurtClip);
    }
    public void SoundCrack()
    {
        effectSource.PlayOneShot(crackEggClip);
    }
    
}
