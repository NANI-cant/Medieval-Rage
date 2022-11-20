using Gameplay.Setup.Impl;
using UnityEditor;
using UnityEngine;

namespace Tools.Editors {
    [CustomEditor(typeof(TraderSpawnPoint))]
    [CanEditMultipleObjects]
    public class TraderSpawnPointEditor : Editor {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(TraderSpawnPoint point, GizmoType gizmo) {
            Gizmos.color = new Color(1f, 1f, 0f, 0.75f);
            Gizmos.DrawSphere(point.Position, 1f);
        }
    }
}