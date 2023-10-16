using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Level.Queries.GetLevel;
using Assets.Code.Domain.Entities;
using Assets.Code.Presentation.Commons.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Presentation.Views
{
    public class LevelsView : View
    {
        [Header("References")]
        [SerializeField] private TMP_Text _currentLevel;
        [SerializeField] private Image _thumbnail;
        [SerializeField] private GameObject _lockedObject;
        [SerializeField] private TMP_Text _theBestScore;
        [SerializeField] private TMP_Text _deaths;

        public int LevelId { get; set; }

        [Inject] private readonly IMediator _mediator;

        private Level _level;

        public override void Refresh()
        {
            _level = _mediator.Send(new GetLevelQuery() { Id = LevelId });

            _currentLevel.text = _level.Id.ToString();
            _thumbnail.sprite = _level.Thumbnail;
            _lockedObject.SetActive(!_level.IsAvailable);
            _theBestScore.text = _level.TheBestScore.ToString();
            _deaths.text = _level.Deaths.ToString();
        }
    }
}