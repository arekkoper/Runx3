using System;

namespace Code.Infrastructure.Services.Cheats
{
    public class Cheat : CheatBase
    {
        private Action _command;
        
        public Cheat(string id, string description, string format, Action command) : base(id, description, format)
        {
            _command = command;
        }

        public void Invoke()
        {
            _command.Invoke();
        }
    }
    
    public class Cheat<T1> : CheatBase
    {
        private Action<T1> _command;
        
        public Cheat(string id, string description, string format, Action<T1> command) : base(id, description, format)
        {
            _command = command;
        }

        public void Invoke(T1 value)
        {
            _command.Invoke(value);
        }
    }
    
    public class Cheat<T1, T2> : CheatBase
    {
        private Action<T1, T2> _command;
        
        public Cheat(string id, string description, string format, Action<T1, T2> command) : base(id, description, format)
        {
            _command = command;
        }

        public void Invoke(T1 value1, T2 value2)
        {
            _command.Invoke(value1, value2);
        }
    }
}