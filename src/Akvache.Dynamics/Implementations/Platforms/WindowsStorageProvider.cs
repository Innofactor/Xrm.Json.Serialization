namespace AkavacheLite.Dynamics.Implementations.Platforms
{
    using System;
    using AkavacheLite.Dynamics.Interfaces;

    public class WindowsStorageProvider : IStorageProvider
    {
        #region Private Fields

        private readonly string _tempData;
        private readonly string _userData;

        #endregion Private Fields

        #region Public Constructors

        public WindowsStorageProvider()
        {
            _userData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _tempData = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
        }

        #endregion Public Constructors

        #region Public Methods

        public string GetPersistentCacheDirectory() =>
            _userData;

        public string GetSecretCacheDirectory() =>
            _userData;

        public string GetTemporaryCacheDirectory() =>
            _tempData;

        #endregion Public Methods
    }
}