using Gameplay.Setup.Impl;
using UnityEditor;
using UnityEngine;

namespace Editors {
    [CustomEditor(typeof(TraderSpawner))]
    [CanEditMultipleObjects]
    public class TraderSpawnPointEditor : Editor {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(TraderSpawner point, GizmoType gizmo) {
            Gizmos.color = new Color(1f, 1f, 0f, 0.75f);
            Gizmos.DrawSphere(point.Position, 1f);
        }
    }
}