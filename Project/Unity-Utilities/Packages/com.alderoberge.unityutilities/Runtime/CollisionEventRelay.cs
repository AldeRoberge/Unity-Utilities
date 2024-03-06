using UnityEngine;
using UnityEngine.Events;

namespace AldeRoberge.UnityUtilities
{
    /// <summary>
    /// Relay collision events to another object or function.
    /// <example>
    /// For example:
    /// <code>
    ///     CollisionListener c = obj.AddComponent<CollisionListener>();
    ///     c.OnTriggerEnterEvent.AddListener((other) => {
    ///        Debug.Log("Obj collided with other!");
    ///     });
    /// </code>
    /// </example>
    ///</summary>
    public class CollisionEventRelay : MonoBehaviour
    {
        public readonly UnityEvent<Collider> OnTriggerEnterEvent = new();
        public readonly UnityEvent<Collider> OnTriggerExitEvent = new();

        public readonly UnityEvent<Collision> OnCollisionEnterEvent = new();
        public readonly UnityEvent<Collision> OnCollisionExitEvent = new();

        public bool DebugCollisions;
        
        private void OnTriggerEnter(Collider other)
        {
            if (DebugCollisions) Debug.Log($"Trigger enter: {other.name}");
            OnTriggerEnterEvent?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (DebugCollisions) Debug.Log($"Trigger exit: {other.name}");
            OnTriggerExitEvent?.Invoke(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (DebugCollisions) Debug.Log($"Collision enter: {other.gameObject.name}");
            OnCollisionEnterEvent?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            if (DebugCollisions) Debug.Log($"Collision exit: {other.gameObject.name}");
            OnCollisionExitEvent?.Invoke(other);
        }
    }
}