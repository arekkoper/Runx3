
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Presenters
{
    public class PlayerPresenter : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<PlayerPresenter> { }
    }
}