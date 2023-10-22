using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Game;
using Code.Application.Modules.Level.Queries.AreAllLevelsAvailable;
using Code.Presentation.Commons;
using UnityEngine.UI;
using Zenject;

namespace Code.Presentation.Interactions
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