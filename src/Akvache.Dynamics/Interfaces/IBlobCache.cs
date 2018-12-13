namespace AkavacheLite.Dynamics.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlobCache : IDisposable
    {
        #region Public Methods

        // Get a single item
        Task<byte[]> Get(string key);

        // Get a list of items
        Task<IDictionary<string, byte[]>> Get(IEnumerable<string> keys);

        // Get all objects of type T
        Task<IEnumerable<T>> GetAllObjects<T>();

        // Return the time which an item was created
        Task<DateTimeOffset?> GetCreatedAt(string key);

        // Return the time which a list of keys were created
        Task<IDictionary<string, DateTimeOffset?>> GetCreatedAt(IEnumerable<string> keys);

        // Get an object serialized via InsertObject
        Task<T> GetObject<T>(string key);

        //// Return a list of all keys. Use for debugging purposes only.
        //Task<IEnumerable<string>> GetAllKeys();
        // Return the time which an object of type T was created
        Task<DateTimeOffset?> GetObjectCreatedAt<T>(string key);

        // Get an object serialized via InsertObject
        Task<T> GetObjectOrDefault<T>(string key);

        // Get a list of objects given a list of keys
        Task<IDictionary<string, T>> GetObjects<T>(IEnumerable<string> keys);

        /*
         * Save items to the store
         */

        // Insert a single item
        Task Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null);

        // Insert a set of items
        Task Insert(IDictionary<string, byte[]> keyValuePairs, DateTimeOffset? absoluteExpiration = null);

        // Insert a single object
        Task InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null);

        // Insert a group of objects
        Task InsertObjects<T>(IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null);

        /*
         * Remove items from the store
         */

        // Delete a single item
        Task Invalidate(string key);

        // Delete a list of items
        Task Invalidate(IEnumerable<string> keys);

        // Deletes all items (regardless if they are objects or not)
        Task InvalidateAll();

        // Deletes all objects of type T
        Task InvalidateAllObjects<T>();

        // Delete a single object (do *not* use Invalidate for items inserted with InsertObject!)
        Task InvalidateObject<T>(string key);

        // Deletes a list of objects
        Task InvalidateObjects<T>(IEnumerable<string> keys);

        /*
         * Get Metadata about items
         */
        /*
         * Utility methods
         */

        // Preemptively drop all expired keys and run SQLite's VACUUM method on the
        // underlying database
        Task Vacuum();

        #endregion Public Methods
    }
}