using Assets.Dune.Scripts.Base;
using UnityEngine;

namespace Assets.Dune.Scripts.UI.Base
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private ScreenView[] _views;

        private void Start()
        {
            OpenScreen(Enums.GameStage.Logo);
        }

        public void OpenScreen(Enums.GameStage type)
        {
            foreach (ScreenView view in _views)
            {
                if (view.Type == type)
                {
                    CreateView(view);
                }
            }
        }

        private void CreateView(ScreenView view)
        {
            Instantiate(view, transform);
        }
    }
}
