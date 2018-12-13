namespace Akavache.Dynamics.Implementations.Platforms
{
    using System;
    using System.IO;
    using Akavache.Dynamics.Interfaces;

    public class AppleiOSStorageProvider : IStorageProvider
    {
        #region Private Fields

        private readonly string _baseFolder;

        #endregion Private Fields

        #region Public Constructors

        public AppleiOSStorageProvider()
        {
            _baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        #endregion Public Constructors

        #region Public Methods

        public string GetPersistentCacheDirectory() =>
            Path.Combine(_baseFolder, "..", "Library");

        public string GetSecretCacheDirectory() =>
            Path.Combine(_baseFolder, "..", "Library");

        public string GetTemporaryCacheDirectory() =>
            Path.Combine(_baseFolder, "..", "Library", "Caches");

        #endregion Public Methods
    }
}