using System;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Level.Queries.GetCurrentLevel;
using Code.Application.Modules.Level.Queries.GetTheBestScore;
using Code.Application.Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Sections
{
    public class InGameMenuSection : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text currentLevelText;
        [SerializeField] private TMP_Text currentScoreText;
        [SerializeField] private TMP_Text theBestScoreText;

        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly HUDSection _hudSection;
        [Inject] private readonly SignalBus _signalBus;
        
        private bool _isOpen;
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            if (!_isOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        private void Open()
        {
            Refresh();
            Show();
            _signalBus.Fire(new OnInGameMenuOpenSignal());
        }

        public void Close()
        {
            Hide();
            _signalBus.Fire(new OnInGameMenuCloseSignal());
        }
        
        private void Show()
        {
            _isOpen = true;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _isOpen = false;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0;
        }

        private void Refresh()
        {
            var currentLevelId = _mediator.Send((new GetCurrentLevelCommand())).Id;
            
            currentLevelText.text = currentLevelId.ToString();
            currentScoreText.text =  ((float)Math.Round(_hudSection.Score, 2)).ToString();
            theBestScoreText.text = _mediator.Send(new GetTheBestScoreQuery() { LevelID = currentLevelId }).ToString();
        }
    }
}