using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            if(type==null)
                throw new ArgumentNullException(nameof(type));

            // TODO: Find mapped type and whether it is a singleton or not
            Type a;
            bool b;
            if (_mapping.ContainsKey(type))
            {
                if (!_mapping[type].ContainsKey(name))
                {
                    var c = _mapping[type].Keys;
                    foreach (var unused in c.Where(string.IsNullOrEmpty))
                        name = "";
                }
                if (!_mapping[type].ContainsKey(name))
                    throw new Exception($"Missing name '{name}'!");
                a = _mapping[type][name].Type;
                b = _mapping[type][name].Singleton && _singletons.ContainsKey(type);
            }
            else
            {
                a=type;
                b = false;
            }

            // TODO: If it is a singleton and already created then return it
            if (b)
            {
                return _singletons[type][name];
            }

            // TODO: Get type constructor
            if(a.GetConstructors().Length==0)
                throw new Exception("Cannot find constructor!");
            var constructor = a.GetConstructors()[0];

            // TODO: Get constructor parameters
            ParameterInfo[] parameters = constructor.GetParameters();
            object?[] invokeParameters=new object[parameters.Length];
            // TODO: Recursively create constructor parameters - call or every one Create(...)
            for (var i=0;i<parameters.Length;i++)
            {
                invokeParameters[i]=Create(parameters[i].ParameterType,parameters[i].Name);
            }
            
            // TODO: Invoke constructor with created parameters
            var created = constructor.Invoke(invokeParameters);

            // TODO: Save object if it is a singleton 
            if (_mapping.ContainsKey(type) && _mapping[type][name].Singleton)
            {
                _singletons[type] = new Dictionary<string, object> {[name] = created};
            }

            // TODO: Return object
            return created;

            //return null;
        }

        public T? Create<T>(string name = "") where T : class
        {
            return Create(typeof(T), name) as T;
        }
    }
}