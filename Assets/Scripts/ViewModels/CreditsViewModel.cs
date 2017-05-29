using System.Collections;
using UnityEngine;
using Noesis;

namespace Assets.Scripts.ViewModels
{
    public class CreditsViewModel : UnityViewModel
    {
        public Visibility ButtonVisibility { get; set; }

        private void Start()
        {
            ButtonVisibility = Visibility.Hidden;
            StartCoroutine(EnableButton());
        }

        public IEnumerator EnableButton()
        {
            yield return new WaitForSeconds(5);
            ButtonVisibility = Visibility.Visible;
            RaisePropertyChanged("ButtonVisibility");
        }

        public MvvmCommand ToMainMenu
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    Game.LoadScene(0);
                });
            }
        }
    }
}
