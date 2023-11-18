using Code.Application.Commons.Interfaces.Services;
using Code.Presentation.Commons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Audios
{
    public class ButtonClickAudio : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Button button;

        [Header("Parameters")]
        [SerializeField] private Application.Commons.Structs.AudioSettings settings;
        [SerializeField] [Tooltip("Select that if sound needs to move through scenes")] private bool sceneThrough;

        [Inject] private readonly IAudioService _audioService;

        private void Start()
        {
            _audioService.Configure($"Audio (ButtonClick/{name})", settings);
            if(!sceneThrough) _audioService.ChangeAudioSourcePosition(transform);
        }

        public void OnEnable()
        {
            button.onClick.AddListener(Play);
        }

        public void OnDisable()
        {
            button.onClick?.RemoveListener(Play);
        }

        private void Play()
        {
            _audioService.Play();

            if (sceneThrough)
            {
                _audioService.DeleteAudioSource();
            }
        }
    }
}