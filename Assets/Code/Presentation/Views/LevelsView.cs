using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game.Commands.ChangeLevel;
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
        [SerializeField] private Button _nextLevel;
        [SerializeField] private Button _previousLevel;
        [SerializeField] private Button _run;

        public int LevelId { get; set; }

        [Inject] private readonly IMediator _mediator;

        private Level _level;

        private void Start()
        {
            _nextLevel.onClick.AddListener(() =>
            {
                LevelId++;
                Refresh();
            });

            _previousLevel.onClick.AddListener(() =>
            {
                LevelId--;
                Refresh();
            });

            _run.onClick.AddListener(() =>
            {
                _mediator.Send(new ChangeLevelCommand() { LevelID = LevelId });
            });
        }

        public override void Refresh()
        {
            _level = _mediator.Send(new GetLevelQuery() { Id = LevelId });

            _currentLevel.text = _level.Id.ToString();
            _thumbnail.sprite = _level.Thumbnail;
            _lockedObject.SetActive(!_level.IsAvailable);
            _theBestScore.text = _level.TheBestScore.ToString();
            _deaths.text = _level.Deaths.ToString();

            _nextLevel.gameObject.SetActive(!(_level.Id == 3));
            _previousLevel.gameObject.SetActive(!(_level.Id == 1));
            _run.interactable = _level.IsAvailable;
        }
    }
}