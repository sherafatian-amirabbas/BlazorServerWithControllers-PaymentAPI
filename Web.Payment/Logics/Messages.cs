using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Web.Payment.Logics
{
    public sealed class Messages : IEnumerable<KeyValuePair<string, string>>
    {
        #region Static Members

        static Lazy<Dictionary<string, string>> _dict = new Lazy<Dictionary<string, string>>(() => GetMessages());
        
        static Messages instance = null;
        public static Messages Instance
        {
            get
            {
                if (instance == null)
                    instance = new Messages();

                return instance;
            }

        }

        #endregion


        #region Constructor

        private Messages() { }

        #endregion


        #region Messages

        public const string CC100 = "Card Owner field is required";
        public const string CC105 = "Card Number field is required";
        public const string CC110 = "CVC field is required";
        public const string CC115 = "CVC Should be numerical and greater than zero";
        public const string CC120 = "Card Number is not valid";
        public const string CC125 = "The card is expired";
        public const string CC130 = "CVC is not valid";

        #endregion


        #region Indexer

        public string this[string key] { get => _dict.Value[key]; }

        #endregion


        #region Private Methods

        private static Dictionary<string, string> GetMessages()
        {
            return typeof(Messages)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(u => u.IsLiteral && !u.IsInitOnly && u.FieldType == typeof(string))
                .Select(u => new { key = u.Name, value = (string)u.GetRawConstantValue() })
                .ToDictionary(u => u.key, u => u.value);
        }

        #endregion


        #region IEnumerable

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _dict.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dict.Value.GetEnumerator();
        }

        #endregion
    }
}
