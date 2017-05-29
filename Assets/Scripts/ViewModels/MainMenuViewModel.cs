using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels
{
    public class MainMenuViewModel : UnityViewModel
    {
        public MvvmCommand NewGame
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    UIManager.Current.PushView("Confirm");
                });
            }
        }

        public MvvmCommand ResumeGame
        {
            get
            {
                return new MvvmCommand(o =>
                {
                                        
                });
            }
        }

        public MvvmCommand ExitGame
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    Game.Quit();
                });
            }
        }
    }    
}
