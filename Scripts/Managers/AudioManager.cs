using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using EventSystem;

namespace isoLand.Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource bgMusicSource;
        [SerializeField] private AudioSource SFXSource;
        [Header("背景音乐")]
        [SerializeField] private AudioClip[] bgMusicClips;
        [Header("特效音乐")]
        [SerializeField] private AudioClip[] SFXMusicClips;
        void Awake()
        {
            EventCenter.AddListener<AudioSourceType, string, bool, float>(MyEventType.PlaySound, PlaySound);
            EventCenter.AddListener<AudioSourceType>(MyEventType.StopSound, StopSound);
            EventCenter.AddListener<AudioSourceType>(MyEventType.PauseSound, PauseSound);
            EventCenter.AddListener<AudioSourceType, float>(MyEventType.SetVolum, SetVolum);
        }
        void OnDestroy()
        {
            EventCenter.RemoveListener<AudioSourceType, string, bool, float>(MyEventType.PlaySound, PlaySound);
            EventCenter.RemoveListener<AudioSourceType>(MyEventType.StopSound, StopSound);
            EventCenter.RemoveListener<AudioSourceType>(MyEventType.PauseSound, PauseSound);
            EventCenter.RemoveListener<AudioSourceType, float>(MyEventType.SetVolum, SetVolum);
        }
        void Start()
        {
            bgMusicSource = gameObject.AddComponent<AudioSource>();
            SFXSource = gameObject.AddComponent<AudioSource>();
            bgMusicSource.clip = bgMusicClips[1];
            //bgMusicSource.Play();
        }
        private void PlaySound(AudioSourceType type, string audioName, bool loop, float delayTime)
        {
            switch (type)
            {
                case AudioSourceType.BackGround:
                    foreach (var item in bgMusicClips)
                    {
                        if (item.name == audioName)
                        {
                            bgMusicSource.clip = item;
                            bgMusicSource.loop = loop;
                            bgMusicSource.PlayDelayed(delayTime);
                            return;
                        }
                        else
                        {
                            throw new Exception(string.Format("没有该音频：{0}", item.name));
                        }
                    }

                    break;
                case AudioSourceType.SFX:
                    foreach (var item in SFXMusicClips)
                    {
                        if (item.name == audioName)
                        {
                            SFXSource.clip = item;
                            SFXSource.loop = loop;
                            SFXSource.PlayDelayed(delayTime);
                            return;
                        }
                        else
                        {
                            throw new Exception(string.Format("没有该音频：{0}", item.name));
                        }
                    }
                    break;
            }
        }
        private void StopSound(AudioSourceType type)
        {
            switch (type)
            {
                case AudioSourceType.BackGround:
                    bgMusicSource.Stop();
                    break;
                case AudioSourceType.SFX:
                    SFXSource.Stop();
                    break;
            }
        }
        private void PauseSound(AudioSourceType type)
        {
            switch (type)
            {
                case AudioSourceType.BackGround:
                    bgMusicSource.Pause();
                    break;
                case AudioSourceType.SFX:
                    SFXSource.Pause();
                    break;
            }
        }
        private void SetVolum(AudioSourceType type, float volum)
        {
            switch (type)
            {
                case AudioSourceType.BackGround:
                    bgMusicSource.volume = volum;
                    break;
                case AudioSourceType.SFX:
                    SFXSource.volume = volum;
                    break;
            }
        }
    }
}
