using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace AldeRoberge.UnityUtilities.ComponentUtils
{
    public static class TryGetComponentUtils
    {
        /// <summary>
        /// TryGetComponent that searches component in children
        /// </summary>
        /// <param name="gameObject">GameObject search started from</param>
        /// <param name="component">Result component</param>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>True if found</returns>
        /// <exception cref="NullReferenceException">GameObject is null</exception>
        /// <exception cref="MissingReferenceException">GameObject was destroyed</exception>
        public static bool TryGetComponentInChildren<T>([NotNull] this GameObject gameObject, out T component)
            where T : Component
        {
            if (gameObject is null)
                throw new NullReferenceException(nameof(gameObject));
            if (!gameObject)
                throw new MissingReferenceException(nameof(gameObject));

            component = gameObject.GetComponentInChildren<T>();
            return component != null;
        }
        
        public static bool TryGetComponentInChildren<T>([NotNull] this Component component, out T result)
            where T : Component
        {
            if (component is null)
                throw new NullReferenceException(nameof(component));
            if (!component)
                throw new MissingReferenceException(nameof(component));

            result = component.GetComponentInChildren<T>();
            return result != null;
        }

        /// <summary>
        /// TryGetComponent that searches component in children
        /// </summary>
        /// <param name="gameObject">GameObject search started from</param>
        /// <param name="componentType">Component type-object</param>
        /// <param name="component">Result component</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">GameObject is null</exception>
        /// <exception cref="MissingReferenceException">GameObject was destroyed</exception>
        public static bool TryGetComponentInChildren([NotNull] this GameObject gameObject, Type componentType,
            out Component component)
        {
            if (gameObject is null)
                throw new NullReferenceException(nameof(gameObject));
            if (!gameObject)
                throw new MissingReferenceException(nameof(gameObject));

            component = gameObject.GetComponentInChildren(componentType);
            return component != null;
        }

        /// <summary>
        /// TryGetComponent that searches component in parents
        /// </summary>
        /// <param name="gameObject">GameObject search started from</param>
        /// <param name="component">Result component</param>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>True if found</returns>
        /// <exception cref="NullReferenceException">GameObject is null</exception>
        /// <exception cref="MissingReferenceException">GameObject was destroyed</exception>
        public static bool TryGetComponentInParent<T>([NotNull] this GameObject gameObject, out T component)
            where T : Component
        {
            if (gameObject is null)
                throw new NullReferenceException(nameof(gameObject));
            if (!gameObject)
                throw new MissingReferenceException(nameof(gameObject));

            component = gameObject.GetComponentInParent<T>();
            return component != null;
        }

        /// <summary>
        /// TryGetComponent that searches component in parents
        /// </summary>
        /// <param name="gameObject">GameObject search started from</param>
        /// <param name="componentType">Component type-object</param>
        /// <param name="component">Result component</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">GameObject is null</exception>
        /// <exception cref="MissingReferenceException">GameObject was destroyed</exception>
        public static bool TryGetComponentInParent([NotNull] this GameObject gameObject, Type componentType,
            out Component component)
        {
            if (gameObject is null)
                throw new NullReferenceException(nameof(gameObject));
            if (!gameObject)
                throw new MissingReferenceException(nameof(gameObject));

            component = gameObject.GetComponentInParent(componentType);
            return component != null;
        }
    }
}