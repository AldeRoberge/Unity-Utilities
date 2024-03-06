using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace AldeRoberge.UnityUtilities.Dispatcher
{
    // From Battlehub's Dispatcher
    // Hint : I recommend you use the Dispatcher from John Baracuda's repository instead of this one
    // Kept for legacy reasons
    public partial class Dispatcher : MonoBehaviour
    {
        private Dispatcher m_current;
        public static Dispatcher Instance { get; private set; }

        private int           m_lock;
        private bool          m_run;
        private Queue<Action> m_wait;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            if (Instance == null)
            {
                Instance = new GameObject("Dispatcher").AddComponent<Dispatcher>();
                DontDestroyOnLoad(Instance.gameObject);
            }
        }

        public void RunOnMainThread(Action action) => InvokeMainThread(action);

        /// <summary>
        /// Runs an action on the Unity main thread
        /// </summary>
        public void InvokeMainThread(Action action)
        {
            while (true)
            {
                if (0 == Interlocked.Exchange(ref m_lock, 1))
                {
                    m_wait.Enqueue(action);
                    m_run = true;
                    Interlocked.Exchange(ref m_lock, 0);
                    break;
                }
            }
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }

            Instance = this;
            m_wait = new Queue<Action>();
        }

        private void Update()
        {
            if (m_run)
            {
                Queue<Action> execute = null;
                if (0 == Interlocked.Exchange(ref m_lock, 1))
                {
                    execute = new Queue<Action>(m_wait.Count);
                    while (m_wait.Count != 0)
                    {
                        var action = m_wait.Dequeue();
                        execute.Enqueue(action);
                    }

                    m_run = false;
                    Interlocked.Exchange(ref m_lock, 0);
                }

                if (execute != null)
                {
                    while (execute.Count != 0)
                    {
                        var action = execute.Dequeue();
                        action();
                    }
                }
            }
        }
    }
}