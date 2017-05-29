using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : UnityViewModel
    {
        private bool _paused = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }            
        }

        private void TogglePause()
        {
            _paused = !_paused;
            Time.timeScale = _paused ? 0f : 1f;
        }

        public MvvmCommand Resume
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    TogglePause();
                });
            }
        }

        public MvvmCommand Quit
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    Application.Quit();
                });
            }
        }
    }
}