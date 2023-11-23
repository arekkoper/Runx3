
using Code.Presentation.Presenters;
using UnityEngine;

namespace Code.Application.Signals
{
    public class OnLevelLoadedSignal
    {
        public PlayerPresenter PlayerPresenter { get; set; }
        public bool WasRestart { get; set; }
    }
}