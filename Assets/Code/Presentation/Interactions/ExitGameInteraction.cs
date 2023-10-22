using Code.Presentation.Commons;

namespace Code.Presentation.Interactions
{
    public class ExitGameInteraction : MonoStatic
    {
        public void Interact()
        {
            UnityEngine.Application.Quit();
        }
    }
}