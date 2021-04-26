namespace CoreLibrary.ViewModels
{
    using Microsoft.AspNetCore.Mvc;

    using System;

    public class BaseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
    }
}