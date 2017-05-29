using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _current;
        
        public static UIManager Current {  get { return _current; } }

        [SerializeField]
        private NoesisView _view;
        [SerializeField]
        private String _initialViewName;
        private Stack<UnityViewModel> _uiStack;
        private List<UnityViewModel> _availableViewModels;

        private void Start()
        {
            _current = this;
            _uiStack = new Stack<UnityViewModel>();
            _availableViewModels = GetComponents<UnityViewModel>().ToList();
            if (String.IsNullOrEmpty(_initialViewName) == false)
            {
                var initialViewModel = _availableViewModels.Single(vm => vm.Name == _initialViewName);
                PushView(initialViewModel);
            }
        }

        public void PushView(String viewName)
        {
            var view = _availableViewModels.Single(v => v.Name == viewName);
            PushView(view);
        }

        public void PushView(UnityViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("viewModel");
            if (viewModel.Xaml == null)
                throw new ArgumentException("viewModel has no xaml set");

            _uiStack.Push(viewModel);
            LoadView();
        }

        public void PopView()
        {
            _uiStack.Pop();
            LoadView();
        }

        private void LoadView()
        {
            var viewModel = _uiStack.FirstOrDefault();
            var xaml = viewModel == null ? null : viewModel.Xaml;
            _view.Xaml = xaml;
            _view.LoadXaml(true);
            if(viewModel != null)
                _view.Content.DataContext = viewModel;
        }
    }
}
