using Assets.Dune.Scripts.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Dune.Scripts.UI.Base
{
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        float _alpha;

        private void Update() // TMP
        {
            if (Input.GetKeyDown(KeyCode.K))
                OpenScreen();
            if (Input.GetKeyDown(KeyCode.S))
                CloseScreen();
        }

        public void OpenScreen()
        {
            _alpha = 0;
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            StartCoroutine(AppearCoroutine(Constants.SCREEN_APPEARING_TIME));
        }

        public void CloseScreen()
        {
            _alpha = 1;
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;

            StartCoroutine(FadeCoroutine(Constants.SCREEN_DISAPPERARING_TIME));
        }

        IEnumerator AppearCoroutine(float time)
        {
            while (_alpha < 1)
            {
                _alpha += Time.timeScale / time;
                _canvasGroup.alpha = _alpha;

                yield return null;
            }   
        }

        IEnumerator FadeCoroutine(float time)
        {
            while (_alpha > 0)
            {
                _alpha -= Time.timeScale / time;
                _canvasGroup.alpha = _alpha;

                yield return null;
            }

            DestroyScreenView();
        }

        public void DestroyScreenView()
        {
            Destroy(gameObject);
        }
    }
}