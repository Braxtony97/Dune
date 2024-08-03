using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Dune.Scripts.Base
{
    public class Master : MonoBehaviour
    {
        public static Master Instance;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}