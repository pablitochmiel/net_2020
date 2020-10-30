using System;
using System.Collections.Generic;

namespace Utils
{
    public class Container : IContainer
    {
        private class TypeWithBehaviour
        {
            public TypeWithBehaviour(Type type, bool singleton)
            {
                Type = type;
                Singleton = singleton;
            }

            public Type Type { get; }
            public bool Singleton { get; }
        }

        private readonly Dictionary<Type, Dictionary<string, TypeWithBehaviour>> _mapping =
            new Dictionary<Type, Dictionary<string, TypeWithBehaviour>>();

        private readonly Dictionary<Type, Dictionary<string, object>> _singletons =
            new Dictionary<Type, Dictionary<string, object>>();

        public void Map(Type from, Type into, string name = "", bool singleton = false)
        {
            if (from == null) throw new ArgumentNullException(nameof(from));
            if (into == null) throw new ArgumentNullException(nameof(into));

            if (!into.IsSubclassOf(from))
                throw new Exception($"Cannot map from {from.Name} into {into.Name}!");

            if (!_mapping.ContainsKey(from))
                _mapping[from] = new Dictionary<string, TypeWithBehaviour>();

            _mapping[from][name] = new TypeWithBehaviour(into, singleton);
        }

        public void Map<TFrom, TInto>(string name = "", bool singleton = false) where TFrom : class where TInto : TFrom
        {
            Map(typeof(TFrom), typeof(TInto), name, singleton);
        }

        public object? Create(Type? type, string name = "")
        {
            // TODO: Throw when type is null

            // TODO: Find mapped type and whether it is a singleton or not

            // TODO: If it is a singleton and already created then return it

            // TODO: Get type constructor

            // TODO: Get constructor parameters

            // TODO: Recursively create constructor parameters - call or every one Create(...)
            
            // TODO: Invoke constructor with created parameters

            // TODO: Save object if it is a singleton 

            // TODO: Return object

            return null;
        }

        public T? Create<T>(string name = "") where T : class
        {
            return Create(typeof(T), name) as T;
        }
    }
}