using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Application.Modules.Game;
using Assets.Code.Application.Modules.Game.Commands.ChangeLevel;
using Assets.Code.Application.Modules.Level.Queries.AreAllLevelsAvailable;
using Assets.Code.Presentation.Commons;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class ContinueGameInteraction : MonoStatic
    {
        [Inject] private readonly IMediator _mediator;
        [Inject] private readonly GameManager _gameManager;

        private void Start()
        {
            //if (_mediator.Send(_gameManager.CurrentLevelID <= 1)
            //{
            //    GetComponent<Button>().interactable = false;
            //}
            
            if (_mediator.Send(new AreAllLevelsAvailableQuery()))
            {
                GetComponent<Button>().gameObject.SetActive(false);
            }
        }

        public void Interact()
        {
            //_mediator.Send(new ChangeLevelCommand() { LevelID = _gameManager.CurrentLevelID });
        }
    }
}