using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScAudioManager : MonoBehaviour {
    public static ScAudioManager Instance;

    [Header("~~~~~~~~ Audio Source ~~~~~~~~")]
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _SFXSource;

    [Header("~~~~~~~~ Audio Clip ~~~~~~~~")]
    public AudioClip background;
    public AudioClip[] clics;

    private void Awake() {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(this.gameObject); }
        else { Destroy(this); }
    }

    public void PlaySFX(AudioClip clip){
        _SFXSource.PlayOneShot(clip);
    }

    public void PlayRandomSFX(AudioClip[] clip) {
        int u = Random.Range(0, clip.Length);
       _SFXSource.PlayOneShot(clip[u]);
    }

    public void PlayMainMusic(AudioClip clip) { 
        _musicSource.Stop();
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    private void Start() {
        PlayMainMusic(background);
    }

}