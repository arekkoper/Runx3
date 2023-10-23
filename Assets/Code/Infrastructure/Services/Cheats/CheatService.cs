using System.Collections.Generic;
using Code.Application.Commons.Interfaces.Mediator;
using Code.Application.Modules.Level.Commands.MakeAvailable;
using Code.Presentation.Commons;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.Cheats
{
    public class CheatService : MonoStatic
    {
        private bool _showConsole;
        private bool _showHelp;
        private string _input;
        private List<object> _commands;

        private Cheat<int> MAKE_LEVEL_AVAILABLE;

        [Inject] private readonly IMediator _mediator;

        protected override void Awake()
        {
            base.Awake();
            
            CheatLoader();

            _commands = new List<object>()
            {
                MAKE_LEVEL_AVAILABLE
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                _showConsole = true;
            }
        }

        private void OnGUI()
        {
            if (!_showConsole) return;

            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return)
            {
                HandleInput();
                _input = "";
            }

            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
            {
                CloseConsole();
            }

            var y = 10f;
            
            GUI.Box(new Rect(0, y, Screen.width, 30), "");
            GUI.backgroundColor = new Color(0, 0, 0, 0);
            GUI.SetNextControlName("CheatInput");
            _input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), _input);
            GUI.FocusControl("CheatInput");
        }

        private void CheatLoader()
        {
            MAKE_LEVEL_AVAILABLE = new Cheat<int>("ma", "Make specific level as an available",
                "ma [levelID]",
                levelID =>
                {
                    _mediator.Send(new MakeLevelAvailableCommand() { Id = levelID });
                });
        }

        private void HandleInput()
        {
            string[] properties = _input.Split(' ');
            
            for(int i = 0; i < _commands.Count; i++)
            {
                var commandBase = _commands[i] as CheatBase;
                
                if(_input == commandBase.ID || properties[0] == commandBase.ID)
                {
                    if(_commands[i] as Cheat != null)
                    {
                        (_commands[i] as Cheat).Invoke();
                    }
                    else if(_commands[i] as Cheat<int> != null)
                    {
                        (_commands[i] as Cheat<int>).Invoke(int.Parse(properties[1]));
                    }
                    else if(_commands[i] as Cheat<float, int> != null)
                    {
                        (_commands[i] as Cheat<float, int>).Invoke(float.Parse(properties[1]), int.Parse(properties[2]));
                    }
                }
            }
        }
        
        private void CloseConsole()
        {
            _showConsole = false;
            _input = "";
            GUI.FocusControl(null);
        }
    }
}