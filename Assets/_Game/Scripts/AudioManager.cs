using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : Singleton<AudioManager>
{
    public static AudioManager Instance = null;
        [Header("SoundFX")]
        public AudioClip[] soundsFX;
        [Header("Music")]

        [Space]
        public AudioClip[] musics;

        [Space]
        public AudioSource musicSource;
        public AudioSource soundSource;

        [Header("Music")]
        public bool isPlayMusic;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            isPlayMusic = true;
        }

        public void PlayMusic(string name, float volume = 1, bool isloop = true)
        {
            if (GameRes.BgMusicSetting==0) return;
            AudioClip s = Array.Find(musics, sound => sound.name == name);
            if (s != null)
            {
                musicSource.clip = s;
                musicSource.loop = isloop;
                musicSource.Play();
                musicSource.volume = volume;
            }
            else
            {
                //Debug.Log("music + " + s);
            }
        }

        public void PlayOneShot(string name, float volume = 1)
        {
            if (GameRes.SoundSetting==0) return;
            AudioClip s = Array.Find(soundsFX, sound => sound.name == name);
            if (s != null)
            {
                soundSource.clip = s;
                soundSource.PlayOneShot(s, volume);
            }
            else
            {
                //Debug.Log("sfx + " + s);
            }
        }

        public void PauseAudio() => AudioListener.pause = true;
        public void ResumeAudio() => AudioListener.pause = false;
        public void Stop()
        {
            musicSource.Stop();
            soundSource.Stop();
            isPlayMusic = false;
        }
        
        public void Pause()
        {
            musicSource.Pause();
            isPlayMusic = false;
        }
        public void Resume()
        {
            //if(GameManager.Instance.m_IsTurnOnAudio)
            {
                musicSource.Play();
                isPlayMusic = false;
            }
        }
}
