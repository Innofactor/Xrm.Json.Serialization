namespace Akavache.Dynamics
{
    using System.Collections.Generic;
    using System.Linq;
    using Akavache.Dynamics.Interfaces;

    internal static class InternalExtensions
    {
        #region Private Fields

        private const int ChunkSize = 950;

        #endregion Private Fields

        #region Public Methods

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> items) =>
            Chunk(items, ChunkSize);

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> items, int size)
        {
            return items
                .Select((o, i) => new { Index = i, Value = o })
                .GroupBy(o => o.Index / size)
                .Select(o => o.Select(p => p.Value));
        }

        public static string GetDatabasePath(this IStorageProvider storageProvider, string applicationName, StorageLocation location)
        {
            string basePath;
            switch (location)
            {
                case StorageLocation.User:
                    basePath = storageProvider.GetPersistentCacheDirectory();
                    break;

                case StorageLocation.Secure:
                    basePath = storageProvider.GetSecretCacheDirectory();
                    break;

                case StorageLocation.Temporary:
                default:
                    basePath = storageProvider.GetTemporaryCacheDirectory();
                    break;
            }
            return System.IO.Path.Combine(basePath, $"{applicationName}.db");
        }

        #endregion Public Methods

        //public static IEnumerable<List<T>> Chunk2<T>(List<T> items, int size)
        //{
        //    var count = items.Count;
        //    for (int i = 0; i < count; i += size)
        //    {
        //        yield return items.GetRange(i, Math.Min(size, items.Count - i));
        //    }
        //}
    }
}