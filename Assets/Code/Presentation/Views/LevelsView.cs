using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game.Commands.ChangeLevel;
using Code.Application.Modules.Level.Queries.GetLevel;
using Code.Domain.Entities;
using Code.Presentation.Commons.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Views
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
            _thumbnail.sprite = Resources.Load<Sprite>($"{_level.ThumbnailPath}");
            _lockedObject.SetActive(!_level.IsAvailable);
            _theBestScore.text = _level.TheBestScore.ToString();
            _deaths.text = _level.Deaths.ToString();

            _nextLevel.GetComponent<Image>().enabled = _level.Id != 13;
            _previousLevel.GetComponent<Image>().enabled = _level.Id != 1;
            _run.interactable = _level.IsAvailable;
        }
    }
}