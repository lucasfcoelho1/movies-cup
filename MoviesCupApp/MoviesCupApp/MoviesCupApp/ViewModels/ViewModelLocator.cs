﻿using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using MoviesCupApp.Repositories;
using MoviesCupApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesCupApp.ViewModels
{
    public class ViewModelLocator
    {
        private UnityContainer _unityContainer;

        public MainViewModel MainViewModel
        {
            get { return _unityContainer.Resolve<MainViewModel>(); }
        }

        public CupResultViewModel CupResultViewModel
        {
            get { return _unityContainer.Resolve<CupResultViewModel>();}
        }

        public ViewModelLocator()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<IMovieRepository, MovieRepository>();
            _unityContainer.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<CupResultViewModel>(new ContainerControlledLifetimeManager());

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(_unityContainer));
        }
    }
}
