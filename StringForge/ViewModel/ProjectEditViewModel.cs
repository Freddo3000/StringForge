﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectEditViewModel.cs" company="RHS">
//   Copyright (c) 2015 Alex Vorobiev
// </copyright>
// <summary>
//   The  class specifying the package container
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StringForge.ViewModel
{
    using System;
    using System.Windows;
    using ReactiveUI;
    using RHSStringTableTools.Model;

    /// <summary>
    /// The project edit view model.
    /// </summary>
    internal class ProjectEditViewModel : EditViewModel
    {
        /// <summary>
        /// Backing field for the name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.RaiseAndSetIfChanged(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets the thing
        /// </summary>
        public Project Thing { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectEditViewModel"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public ProjectEditViewModel(Project item)
        {
            this.Thing = item;

            var canOk = this.WhenAny(vm => vm.Name, vm => !string.IsNullOrWhiteSpace(vm.Value));
            this.OkCommand = ReactiveCommand.Create(canOk);
            this.OkCommand.Subscribe(this.OkCommandExecute);

            this.SetProperties();
        }

        /// <summary>
        /// Set the properties
        /// </summary>
        private void SetProperties()
        {
            this.Name = this.Thing.Name;
        }

        /// <summary>
        /// Execute the ok command
        /// </summary>
        /// <param name="window">
        /// The window.
        /// </param>
        private void OkCommandExecute(object window)
        {
            this.Thing.Name = this.Name;

            ((Window)window).Close();
        }
    }
}