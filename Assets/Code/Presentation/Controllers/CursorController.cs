﻿using System;
using Code.Application.Signals;
using UnityEngine;
using Zenject;

namespace Code.Presentation.Controllers
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CursorController : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        public CursorController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<OnLevelLoadedSignal>(HideCursor);
            _signalBus.Subscribe<OnPlayerWinSignal>(ShowCursor);
            _signalBus.Subscribe<OnPlayerKilledSignal>(ShowCursor);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<OnLevelLoadedSignal>(HideCursor);
            _signalBus.Unsubscribe<OnPlayerWinSignal>(ShowCursor);
            _signalBus.Unsubscribe<OnPlayerKilledSignal>(ShowCursor);
        }

        private void ShowCursor()
        {
            Cursor.visible = true;
        }
        
        private void HideCursor()
        {
            Cursor.visible = false;
        }


    }
}