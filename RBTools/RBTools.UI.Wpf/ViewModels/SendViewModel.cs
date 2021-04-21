﻿using System.Linq;
using System.Windows.Input;
using RBTools.Application;
using RBTools.Application.Communication.DTO;
using RBTools.UI.Wpf.Models;
using RBTools.UI.Wpf.SeedWork;
using RBTools.UI.Wpf.SeedWork.Mapping;

namespace RBTools.UI.Wpf.ViewModels
{
    public class SendViewModel : NotifyPropertyChanged
    {
        private string _summary;
        private string _description;
        private string _testingDone;
        private string _reviewId;
        private string _updateDescription;
        private ReviewType _reviewType;
        private string _revision;

        public SendViewModel(Settings settings, PostCommandIssuer issuer)
        {
            Settings = settings;
            Issuer = issuer;
            ReviewType = ReviewTypes.First();
        }

        public Settings Settings { get; }
        public PostCommandIssuer Issuer { get; }
        public ReviewType[] ReviewTypes { get; } = new[] { ReviewType.PreCommitNew, ReviewType.PreCommitUpdate, ReviewType.PostCommitNew, ReviewType.PostCommitUpdate };

        public ICommand PostCommand => new RelayCommand<RbtPostDto>(o => Issuer.Issue(Mapper.CreateDto(this)));

        public string Summary
        {
            get => _summary;
            set
            {
                if (_summary == value) return;
                _summary = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public string TestingDone
        {
            get => _testingDone;
            set
            {
                if (_testingDone == value) return;
                _testingDone = value;
                OnPropertyChanged();
            }
        }

        public ReviewType ReviewType
        {
            get => _reviewType;
            set
            {
                if (_reviewType == value) return;
                _reviewType = value;
                OnPropertyChanged();
            }
        }

        public string Revision
        {
            get => _revision;
            set
            {
                if (_revision == value) return;
                _revision = value;
                OnPropertyChanged();
            }
        }

        public string ReviewId
        {
            get => _reviewId;
            set
            {
                var actualValue = string.Concat(value.Where(c => c >= '0' && c <= '9'));
                if (_reviewId == actualValue) return;
                _reviewId = actualValue;
                OnPropertyChanged();
            }
        }

        public string UpdateDescription
        {
            get => _updateDescription;
            set
            {
                if (_updateDescription == value) return;
                _updateDescription = value;
                OnPropertyChanged();
            }
        }
    }
}
