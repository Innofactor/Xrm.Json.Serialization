using System;

namespace AkavacheLite.Dynamics
{
    public class KeyNotFoundException : Exception
    {
        #region Public Constructors

        public KeyNotFoundException()
            : base()
        { }

        public KeyNotFoundException(string key)
            : base(GetKeyMessage(key))
        { }

        #endregion Public Constructors

        #region Private Methods

        private static string GetKeyMessage(string key) =>
            $"The key `{key}` was not found or has already expired.";

        #endregion Private Methods
    }
}