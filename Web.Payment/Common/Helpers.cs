using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using Web.Payment.Logics;
using Web.Payment.Logics.Services;


namespace Web.Payment.Common
{
    public static class Helpers
    {
        #region Extension Methods

        public static string GetDisplayName<T>(this T enumValue) where T : Enum
        {
            DisplayAttribute displayAttribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();

            string displayName = displayAttribute?.GetName();

            return displayName ?? enumValue.ToString();
        }


        public static IEnumerable<ResultError> ToErrorList(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(u => u.Errors)
                .Join(Messages.Instance,
                    modelError => modelError.ErrorMessage,
                    keyPair => keyPair.Key,
                    (modelError, keyPair) => new ResultError(keyPair.Key, keyPair.Value))
                .ToList();
        }


        public static bool ContainsCode(this IEnumerable<IResultError> errors, string code)
        {
            return errors != null && errors.Any(u => u.Code == code);
        }


        public static Dictionary<string, string> ToErrorDict(this IEnumerable<IResultError> errors)
        {
            var dict = errors != null ?
                errors.ToDictionary(u => u.Code, u => u.ErrorMessage) :
                new Dictionary<string, string>();
            return dict;
        }

        #endregion
    }
}
