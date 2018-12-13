namespace Akavache.Dynamics
{
    using System;
    using System.Linq;
    using Akavache.Dynamics.Implementations;
    using Akavache.Dynamics.Interfaces;

    // based on the excelent work of Akavache
    public static class BlobCache
    {
        #region Private Fields

        private static string _applicationName;
        private static Lazy<IBlobCache> _localMachine;
        private static IStorageProvider _storageProvider;
        private static Lazy<IBlobCache> _userAccount;
        //static Lazy<ISecureBlobCache> _secure;

        private static IBlobCache localMachine;

        //static ISecureBlobCache secure;
        private static bool shutdownRequested;

        private static IBlobCache userAccount;

        #endregion Private Fields

        #region Public Constructors

        static BlobCache()
        {
            _localMachine = new Lazy<IBlobCache>(() =>
                new PersistentBlobCache(GetDatabasePath(ApplicationName, StorageLocation.Temporary)));
            _userAccount = new Lazy<IBlobCache>(() =>
                new PersistentBlobCache(GetDatabasePath(ApplicationName, StorageLocation.User)));
            //_secure = new Lazy<ISecureBlobCache>(() =>
            //    new SQLitePersistentBlobCache(GetDatabasePath(ApplicationName, StorageLocation.Secure)));
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Your application's name. Set this at startup, this defines where
        /// your data will be stored (usually at %AppData%\[ApplicationName])
        /// </summary>
        public static string ApplicationName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_applicationName))
                {
                    throw new Exception($"You must set {nameof(BlobCache)}.{nameof(ApplicationName)} on startup.");
                }

                return _applicationName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _applicationName = value;
                    return;
                }
                var invalidChars = System.IO.Path.GetInvalidFileNameChars();
                if (value.Any(o => invalidChars.Contains(o)))
                {
                    throw new Exception($"{nameof(BlobCache)}.{nameof(ApplicationName)} cannot have any of these characters: " + string.Join(" ", invalidChars));
                }

                _applicationName = value;
            }
        }

        /// <summary>
        /// The local machine cache. Store data here that is unrelated to the
        /// user account or shouldn't be uploaded to other machines (i.e.
        /// image cache data)
        /// </summary>
        public static IBlobCache LocalMachine => 
            _localMachine.Value;

        public static IStorageProvider StorageProvider
        {
            get => _storageProvider ?? throw new Exception($"You must set {nameof(BlobCache)}.{nameof(StorageProvider)} on startup.");
            set => _storageProvider = value;
        }

        /// <summary>
        /// The user account cache. Store data here that is associated with
        /// the user; in large organizations, this data will be synced to all
        /// machines via NT Roaming Profiles.
        /// </summary>
        public static IBlobCache UserAccount => 
            _userAccount.Value;

        #endregion Public Properties

        ///// <summary>
        ///// An IBlobCache that is encrypted - store sensitive data in this
        ///// cache such as login information.
        ///// </summary>
        //public static ISecureBlobCache Secure => _secure.Value;

        #region Public Methods

        public static string GetDatabasePath(string applicationName, StorageLocation location) => 
            StorageProvider.GetDatabasePath(applicationName, location);

        #endregion Public Methods

    }
}