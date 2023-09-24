using System;
using UnityEngine;

namespace _GameCore_.Core
{
    public class ECSCore : MonoBehaviour
    {
        private GameSystems _gameSystems;
        private void Awake()
        {
            _gameSystems = new GameSystems(Contexts.sharedInstance);
        }
        
        private void Start()
        {
            _gameSystems.Initialize();
        }


        private void Update()
        {
            _gameSystems.Execute();
        }

        private void LateUpdate()
        {
            _gameSystems.Cleanup();
        }

        private void OnDestroy()
        {
            _gameSystems.TearDown();
        }
    }
}