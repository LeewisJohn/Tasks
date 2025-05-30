﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NotEmptyGuidAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";
        public NotEmptyGuidAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object? value)
        {
            //NotEmpty doesn't necessarily mean required
            if (value is null)
                return true;

            switch (value)
            {
                case Guid guid:
                    return guid != Guid.Empty;
                default:
                    return true;
            }
        }
    }
}
