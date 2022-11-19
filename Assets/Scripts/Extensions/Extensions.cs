using UnityEngine;

namespace Extensions {
    public static class Extensions{
        public static Vector3 ToXZ(this Vector2 vector) => new Vector3(vector.x, 0, vector.y);
    }
}