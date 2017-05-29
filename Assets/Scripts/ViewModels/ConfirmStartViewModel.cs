using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels
{
    public class ConfirmStartViewModel : UnityViewModel
    {
        public MvvmCommand ConfirmStart
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    Game.LoadScene(2);
                });
            }
        }

        public MvvmCommand Cancel
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    UIManager.Current.PopView();
                });
            }
        }
    }
}
