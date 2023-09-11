using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource settingsButtonSound;
    [SerializeField] AudioSource settingsElementsButtonSound;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource playerBlowSound;
    [SerializeField] AudioSource finishSound;
    [SerializeField] AudioSource buySound;
    [SerializeField] AudioSource exitButtonSound;
    [SerializeField] AudioSource nextLevelActiveSound;
    


    [SerializeField] AudioClip buttonSoundClip;
    [SerializeField] AudioClip settingsButtonSoundClip;
    [SerializeField] AudioClip settingsElementsButtonSoundClip;
    [SerializeField] AudioClip hitSoundClip;
    [SerializeField] AudioClip playerBlowSoundClip;
    [SerializeField] AudioClip finishSoundClip;
    [SerializeField] AudioClip buySoundClip;
    [SerializeField] AudioClip exitButtonSoundClip;
    [SerializeField] AudioClip nextLevelActiveSoundClip;

    

    public void ButtonSound()
    {
        buttonSound.PlayOneShot(buttonSoundClip);

    }

    public void SettingsButtonSound()
    {
        settingsButtonSound.PlayOneShot(settingsButtonSoundClip);
    }

    public void SettingsElementsButtonSound()
    {
        settingsElementsButtonSound.PlayOneShot(settingsElementsButtonSoundClip);
    }

    public void HitSound()
    {
        hitSound.PlayOneShot(hitSoundClip);
    }

    public void PlayerBlowSound()
    {
        playerBlowSound.PlayOneShot(playerBlowSoundClip,.5f);
    }

    public void FinishSound()
    {
        finishSound.PlayOneShot(finishSoundClip);
    }

    public void BuySound()
    {
        buySound.PlayOneShot(buySoundClip);
    }

    public void ExitButtonSound()
    {
        exitButtonSound.PlayOneShot(exitButtonSoundClip);
    }

    public void NextLevelActiveSound()
    {
        nextLevelActiveSound.PlayOneShot(nextLevelActiveSoundClip);
    }
}
