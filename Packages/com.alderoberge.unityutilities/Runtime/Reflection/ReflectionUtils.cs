using System;
using System.Collections.Generic;
using System.Linq;

namespace AldeRoberge.UnityUtilities.Reflection
{
    public static class ReflectionUtils
    {
        /// <summary>
        /// Get all subclasses of a given type
        /// Code example :
        /// ReflectionUtils.GetAllTypes(typeof(ObjectTypeList<>));
        /// </summary>
        public static List<Type> GetAllTypes(Type genericType)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.BaseType != null && type.BaseType.Name == genericType.Name)
                .ToList();
        }
        
        /// <summary>
        /// Used to check if class typeA implements typeB. Works with generic type.
        /// Source : https://stackoverflow.com/questions/457676/check-if-a-class-is-derived-from-a-generic-class
        /// </summary>
        public static bool Satisfies(this Type typeA, Type typeB)
        {
            var types = new List<Type>(typeA.GetInterfaces());
            for (var t = typeA; t != null; t = t.BaseType)
            {
                types.Add(t);
            }
            return types.Any(t =>
                t == typeB ||
                t.IsGenericType && (t.GetGenericTypeDefinition() == typeB));
        }
    }
}