using System.Collections.Generic;
using Architecture.Abstraction;
using UnityEngine;

namespace Architecture {
    public class UpdateContainer : MonoBehaviour {
        private List<IUpdatable> _updatables = new List<IUpdatable>();

        private void Update() {
            foreach (var updatable in _updatables) {
                updatable.Update();
            }
        }

        public void Add(params IUpdatable[] updatables) {
            foreach (var updatable in updatables) {
                TryAdd(updatable);
            }
        }

        public bool TryAdd(IUpdatable updatable) {
            if (_updatables.Contains(updatable)) return false;

            _updatables.Add(updatable);
            return true;
        }

        public void Remove(params IUpdatable[] updatables) {
            foreach (var updatable in updatables) {
                TryRemove(updatable);
            }
        }

        public bool TryRemove(IUpdatable updatable) {
            return _updatables.Remove(updatable);
        }
    }
}