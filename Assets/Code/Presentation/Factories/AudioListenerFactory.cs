using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Code.Presentation.Factories
{
    public class AudioListenerFactory : MonoBehaviour
    {
        public Transform Parent { get; private set; }

        public class Factory : PlaceholderFactory<AudioListenerFactory> { }

        private void OnEnable()
        {
            Parent = transform.parent;
        }
    }
}
