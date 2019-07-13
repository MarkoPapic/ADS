using System;
using System.Collections.Generic;

namespace ADS.DataStructures
{
    public class HashTable<TKey, TValue>
    {
        private const int INITIAL_CAPACITY = 32;

        private Bucket<TKey, TValue>[] data;
        private int _count;

        public int Count => this._count;

        public HashTable()
        {
            this.data = GetEmptyData(INITIAL_CAPACITY);
        }

        public void Add(TKey key, TValue value)
        {
            int index = Hash(key, this.data.Length);
            bool existingKey = this.data[index].Insert((key, value));
            if (!existingKey)
                this._count++;
            if (ShouldRehashUp())
                RehashUp();
        }

        public TValue Get(TKey key)
        {
            int index = Hash(key, this.data.Length);
            return this.data[index].Get(key);
        }

        public TValue this[TKey key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Add(key, value);
            }
        }

        public bool Remove(TKey key)
        {
            int index = Hash(key, this.data.Length);
            bool actuallyRemoved = this.data[index].Remove(key);
            if (actuallyRemoved)
                this._count--;
            if (ShouldRehashDown())
                RehashDown();
            return actuallyRemoved;
        }

        public bool ContainsKey(TKey key)
        {
            int index = Hash(key, this.data.Length);
            return this.data[index].ContainsKey(key);
        }

        private int Hash(TKey key, int limit)
        {
            int scaledHash = key.GetHashCode() % limit;
            int absoluteHash = scaledHash < 0 ? scaledHash * -1 : scaledHash;
            return absoluteHash;
        }

        private Bucket<TKey, TValue>[] GetEmptyData(int size)
        {
            Bucket<TKey, TValue>[] result = new Bucket<TKey, TValue>[size];
            for (int i = 0; i < size; i++)
                result[i] = new Bucket<TKey, TValue>();
            return result;
        }

        private void RehashUp()
        {
            int newCapacity = this.data.Length * 2;
            Bucket<TKey, TValue>[] newData = GetEmptyData(newCapacity);
            for (int i = 0; i < this.data.Length; i++)
            {
                (TKey, TValue)[] bucketItems = this.data[i].GetAll();
                if (bucketItems.Length > 0)
                {
                    for (int j = 0; j < bucketItems.Length; j++)
                    {
                        int newIndex = Hash(bucketItems[j].Item1, newCapacity);
                        newData[newIndex].Insert(bucketItems[j]);
                    }
                }
            }
            this.data = newData;
        }

        private void RehashDown()
        {
            int newCapacity = (int)this.data.Length / 4;
            Bucket<TKey, TValue>[] newData = GetEmptyData(newCapacity);
            for (int i = 0; i < newCapacity; i++)
            {
                (TKey, TValue)[] bucketItems = this.data[i].GetAll();
                if (bucketItems.Length > 0)
                {
                    for (int j = 0; j < bucketItems.Length; j++)
                    {
                        int newIndex = Hash(bucketItems[j].Item1, newCapacity);
                        newData[newIndex].Insert(bucketItems[j]);
                    }
                }
            }
            this.data = newData;
        }

        private bool ShouldRehashUp() => Count > this.data.Length * 0.75;
        private bool ShouldRehashDown() => Count < this.data.Length / 4 && Count > 16;

        private class Bucket<TBucketKey, TBucketValue>
        {
            private List<(TBucketKey, TBucketValue)> data;

            public int Count => this.data.Count;

            public Bucket()
            {
                this.data = new List<(TBucketKey, TBucketValue)>();
            }

            //We return the boolean value that indicates wether that key already existed in the bucket.
            //This is to be able to update the Count property from HashTable class on every Insert/Remove.
            //This way, instead of iterating through each bucket and summing elements, we can return hash table count in constant time.
            public bool Insert((TBucketKey, TBucketValue) element)
            {
                if (this.data.Count == 0)
                    this.data.Add(element);
                else
                {
                    for (int i = 0; i < this.data.Count; i++)
                    {
                        if (this.data[i].Item1.Equals(element.Item1))
                        {
                            this.data[i] = element;
                            return true;
                        }
                    }
                    this.data.Add(element);
                }
                return false;
            }

            public TBucketValue Get(TBucketKey key)
            {
                if (this.data.Count == 1)
                    return this.data[0].Item2;
                else if (this.data.Count == 0)
                    throw new InvalidOperationException("Key doesn't exist.");
                else
                {
                    for (int i = 0; i < this.data.Count; i++)
                    {
                        if (this.data[i].Item1.Equals(key))
                            return this.data[i].Item2;
                    }
                    throw new InvalidOperationException("Key doesn't exist.");
                }
            }

            public bool ContainsKey(TBucketKey key)
            {
                if (this.data.Count == 1)
                    return this.data[0].Item1.Equals(key);
                else if (this.data.Count == 0)
                    return false;
                else
                {
                    for (int i = 0; i < this.data.Count; i++)
                    {
                        if (this.data[i].Item1.Equals(key))
                            return true;
                    }
                    return false;
                }
            }

            public bool Remove(TBucketKey key)
            {
                if (this.data.Count == 1)
                {
                    this.data.Clear();
                    return true;
                }
                else if (this.data.Count == 0)
                    return false;
                else
                {
                    int indexForDeletion = -1;
                    for (int i = 0; i < this.data.Count; i++)
                    {
                        if (this.data[i].Item1.Equals(key))
                        {
                            indexForDeletion = i;
                            break;
                        }
                    }
                    if (indexForDeletion == -1)
                        return false;
                    else
                    {
                        this.data.RemoveAt(indexForDeletion);
                        return true;
                    }
                }
            }

            public (TBucketKey, TBucketValue)[] GetAll()
            {
                return this.data.ToArray();
            }
        }
    }
}
