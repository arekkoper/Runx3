using Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using AudioSettings = Code.Application.Commons.Structs.AudioSettings;

namespace Assets.Code.Presentation.Audios
{
    public class MainMenuAudio : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private AudioSettings settings;

        [Inject] private readonly IAudioService _audioService;

        private void Start()
        {
            _audioService.Configure($"Audio (MainMusic)", settings);

            _audioService.Play();
        }
    }
}


