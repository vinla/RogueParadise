using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ViewModels
{
    public class PauseMenuViewModel : UnityViewModel
    {
        private bool _paused;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();                
            }
        }

        private void TogglePause()
        {
            _paused = !_paused;
            if (_paused)
                UIManager.Current.PushView(this);
            else
                UIManager.Current.PopView();
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
                return new MvvmCommand(o => {
                    Game.Quit();
                });
            }
        }
    }
}
