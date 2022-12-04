using UnityEngine;

namespace Extensions {
    public static class Extensions{
        public static Vector3 ToXZ(this Vector2 vector) => new Vector3(vector.x, 0, vector.y);

        public static T[] Concat<T>(this T[] selfArray, T[] otherArray) {
            var result = new T[selfArray.Length + otherArray.Length];
            selfArray.CopyTo(result, 0);
            otherArray.CopyTo(result, 0);
            return result;
        }
        
        public static T[] Concat<T>(this T[] selfArray, T another) {
            var result = new T[selfArray.Length + 1];
            selfArray.CopyTo(result, 0);
            result[selfArray.Length] = another;
            return result;
        }
    }
}