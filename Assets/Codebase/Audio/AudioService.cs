using System;
using Codebase.Assets;
using Codebase.Audio;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Codebase.Controllers
{
    public class AudioService : MonoBehaviour, IInitializable
    {
        private Sounds _sounds;
        private AudioSource _musicSource1;
        private AudioSource _musicSource2;
        private AudioSource _sfxSource;
        private AudioSource _carSource;
        private float _pitchRatio = 0.2f;
        private float _durationFade = 0.5f;
        private int _click;

        public static AudioService Instance;
        public Sounds Sounds => _sounds;

        private void Awake()
        {
            Instance = this;
        }

        [Inject]
        public void Init(AssetsProvider assetsProvider)
        {
            _sounds = assetsProvider.Sounds;
        }
        
        public void Initialize()
        {
            _musicSource1 = gameObject.AddComponent<AudioSource>();
            _musicSource2 = gameObject.AddComponent<AudioSource>();
            _sfxSource = gameObject.AddComponent<AudioSource>();
            _carSource = gameObject.AddComponent<AudioSource>();

            _musicSource1.volume = 0;
            _musicSource1.loop = true;
            _musicSource2.loop = true;
            _carSource.loop = true;
            _carSource.clip = Sounds.Engine;
            _carSource.volume = 0;

            
            PlayMusic(_sounds.MainTheme);
        }

        public void PlayMusic(AudioClip music)
        {
            _musicSource1.clip = music;
            _musicSource1.Play();
            _musicSource1.DOFade(1, _durationFade)
                .SetEase(Ease.InCubic);
        }

        public void StopMusic()
        {
            _musicSource1.DOFade(0, _durationFade)
                .SetEase(Ease.InCubic)
                .OnComplete(_musicSource1.Stop);
        }

        public void PlaySFX(AudioClip sound)
        {
            _sfxSource.PlayOneShot(sound);
        }

        public void SetPitchEngine(float verticalInput)
        {
            _carSource.pitch = 1 + verticalInput * _pitchRatio;
        }

        public void OnSoundEngine()
        {
            _carSource.Play();
            _carSource.DOFade(1, _durationFade)
                .SetEase(Ease.InCubic);
        }

        public void OffSoundEngine()
        {
            _carSource.Stop();
            _carSource.volume = 0;
        }

        public void SetMusicMute(bool value)
        {
            _musicSource1.mute = value;
        }

        public void SetSoundMute(bool value)
        {
            _sfxSource.mute = value;
            _carSource.mute = value;
        }
    }
}