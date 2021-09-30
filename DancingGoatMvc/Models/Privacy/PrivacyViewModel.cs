﻿using System.Collections.Generic;
using System.Linq;

namespace DancingGoat.Models.Privacy
{
    public class PrivacyViewModel
    {
        public bool DemoDisabled { get; set; }


        public bool ShowSavedMessage { get; set; }


        public bool ShowErrorMessage { get; set; }


        public IEnumerable<ConsentViewModel> Constents { get; set; } = Enumerable.Empty<ConsentViewModel>();
    }
}