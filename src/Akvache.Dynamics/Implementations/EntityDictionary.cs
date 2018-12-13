namespace Akvache.Dynamics.Implementations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Akavache.Dynamics.Implementations;
    using Microsoft.Xrm.Sdk;

    public class EntityDictionary : IDictionary<Guid, Entity>
    {
        #region Private Fields

        private PersistentBlobCache cache;

        #endregion Private Fields

        #region Public Constructors

        public EntityDictionary(string databasePath)
        {
            cache = new PersistentBlobCache(databasePath);
        }

        #endregion Public Constructors

        #region Public Properties

        public int Count =>
            Keys.Count;

        public bool IsReadOnly =>
            false;

        public ICollection<Guid> Keys
        {
            get
            {
                var task = cache.GetAllKeys();
                task.Wait();

                return task.Result.Select(x => Guid.Parse(x.Key)).ToList();
            }
        }

        public ICollection<Entity> Values
        {
            get
            {
                var task = cache.GetAllObjects<Entity>();
                task.Wait();

                return task.Result.ToList();
            }
        }

        #endregion Public Properties

        #region Public Indexers

        public Entity this[Guid key]
        {
            get
            {
                var task = cache.GetObject<Entity>(key.ToString());
                task.Wait();

                return task.Result;
            }

            set
            {
                var task = cache.InsertObject<Entity>(key.ToString(), value);
            }
        }

        #endregion Public Indexers

        #region Public Methods

        public void Add(Guid key, Entity value) =>
            this[key] = value;

        public void Add(KeyValuePair<Guid, Entity> item) =>
            Add(item.Key, item.Value);

        public void Clear() =>
            cache.InvalidateAll().Wait();

        public bool Contains(KeyValuePair<Guid, Entity> item) => throw new NotImplementedException();

        public bool ContainsKey(Guid key) => 
            Keys.Contains(key);

        public void CopyTo(KeyValuePair<Guid, Entity>[] array, int arrayIndex) => throw new NotImplementedException();

        public IEnumerator<KeyValuePair<Guid, Entity>> GetEnumerator() => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

        public bool Remove(Guid key) => throw new NotImplementedException();

        public bool Remove(KeyValuePair<Guid, Entity> item) => throw new NotImplementedException();

        public bool TryGetValue(Guid key, out Entity value) => throw new NotImplementedException();

        #endregion Public Methods
    }
}