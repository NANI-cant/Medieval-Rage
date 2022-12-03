using System;
using UnityEngine;

namespace Extensions {
    public static class CleanCode {
        public static T With<T>(this T self, Action<T> set) {
            set.Invoke(self);
            return self;
        }
        
        public static T With<T>(this T self, Action<T> set, Func<bool> when) {
            if (when()) set.Invoke(self);
            return self;
        }
        
        public static T With<T>(this T self, Action<T> set, bool when) {
            if (when) set.Invoke(self);
            return self;
        }

        public static T Do<T>(this T self, Action<T> action, bool when) {
            if (when) action.Invoke(self);
            return self;
        }

        public static TComponent AddComponentSingle<TComponent>(this GameObject self) where TComponent : Component {
            if (!self.TryGetComponent<TComponent>(out var component)) {
                component = self.AddComponent<TComponent>();
            }
            return component;
        }
        
        public static TComponent AddComponentSingle<TComponent>(this Component self) where TComponent : Component {
            if (!self.TryGetComponent<TComponent>(out var component)) {
                component = self.gameObject.AddComponent<TComponent>();
            }
            return component;
        }
    }
}