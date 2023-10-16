
using Assets.Code.Application.Commons.Interfaces.Mediator;
using Assets.Code.Presentation.Commons;
using Assets.Code.Presentation.Commons.Interfaces;
using Assets.Code.Presentation.Controllers;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class ShowViewInteraction : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private View _view;

        [Inject] private readonly MainMenuController _controller;

        public void Interact()
        {
            _controller.Show(_view);
        }
    }
}