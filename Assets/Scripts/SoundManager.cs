using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;


    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] laserSounds;

    [SerializeField]
    private AudioClip laserShot,
        onHit,
        onEnemyDestroyed,
        onGetPower,
        onBunkerHit;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else Destroy(gameObject);
        audioSource = GetComponent<AudioSource>();
    }


    public static void PlayOnLaserShot()
    {
        var id = Random.Range(0, instance.laserSounds.Length);
        PlaySFX(instance.laserSounds[id]);
    }

    public static void PlayOnHit() => PlaySFX(instance.onHit);
    
    public void PlayOnEnemyDestroyed() => PlaySFX(onEnemyDestroyed);

    public void PlayOnGetPower() => PlaySFX(onGetPower);

    public void PlayOnBunkerHit() => PlaySFX(onBunkerHit);


    public static void PlaySFX(AudioClip clip)
    {
        instance.audioSource.PlayOneShot(clip);
    }
    
}
