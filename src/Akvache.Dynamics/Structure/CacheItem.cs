namespace Akvache.Dynamics.Structure
{
    internal class CacheItem
    {
        #region Public Properties

        public long CreatedAt
        {
            get;
            set;
        }

        public string Item
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public long? Time
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}