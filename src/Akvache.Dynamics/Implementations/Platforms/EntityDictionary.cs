namespace Akvache.Dynamics.Implementations.Platforms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Xrm.Sdk;

    public class EntityDictionary : IDictionary<Guid, Entity>
    {
        public Entity this[Guid key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Guid> Keys => throw new NotImplementedException();

        public ICollection<Entity> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Guid key, Entity value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<Guid, Entity> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Guid, Entity> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Guid key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Guid, Entity>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Guid, Entity>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Guid, Entity> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Guid key, out Entity value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}