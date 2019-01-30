using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip hurtSound;
    //public static AudioClip boatIdle;
    //public static AudioClip rainIdle;
    public static AudioClip harpoonSound;
    public static AudioClip spookySound;
    public static AudioClip bombSound;
    public static AudioClip bomberSound;
    public static AudioClip explosionSound;
    public AudioClip boatIdle;
    public AudioClip rainIdle;
    static AudioSource audioSource;



    private void Start()
    {
        hurtSound = Resources.Load<AudioClip>("Monster_Hurt");
        boatIdle = Resources.Load<AudioClip>("Boat_Idle");
        rainIdle = Resources.Load<AudioClip>("Rain_Idle");
        harpoonSound = Resources.Load<AudioClip>("Harpoon_Gun");
        spookySound = Resources.Load<AudioClip>("Underwater_Spooky");
        //mgSound = Resources.Load<AudioClip>("GunShot");
        //bombSound = Resources.Load<AudioClip>("bombSound");
        //bomberSound = Resources.Load<AudioClip>("bomberSound");
        //cannonSound = Resources.Load<AudioClip>("cannonSound");
        //explosionSound = Resources.Load<AudioClip>("explosionSound");
        //music = Resources.Load<AudioClip>("TakeTheLead");
        audioSource = GetComponent<AudioSource>();
        PlayAmbience();
        Invoke("PlaySoundStinger", 9);
    }

    void PlayAmbience()
    {
        audioSource.PlayOneShot(boatIdle, 0.3f);
        audioSource.PlayOneShot(rainIdle, 0.6f);
    }


    public static void PlaySoundHurt()
    {

        audioSource.PlayOneShot(hurtSound);
    }

    public static void PlaySoundHarpoon()
    {

        audioSource.PlayOneShot(harpoonSound, 0.7f);

    }

    public void PlaySoundStinger()
    {

        audioSource.PlayOneShot(spookySound, 0.8f);

    }

    //public static void PlaySoundCannon()
    //{

    //    audioSource.PlayOneShot(cannonSound, 0.5f);

    //}

    //public static void PlaySoundBomb()
    //{

    //    audioSource.PlayOneShot(bombSound, 0.05f);

    //}

    //public static void PlaySoundBomber()
    //{

    //    audioSource.PlayOneShot(bomberSound);

    //}

    //public static void PlaySoundExplosion()
    //{

    //    audioSource.PlayOneShot(explosionSound, 0.4f);

    //}
}
