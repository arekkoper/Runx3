using Assets.Code.Presentation.Commons;

namespace Assets.Code.Presentation.Statics.Interactions
{
    public class ExitGameInteraction : MonoStatic
    {
        public void Interact()
        {
            UnityEngine.Application.Quit();
        }
    }
}