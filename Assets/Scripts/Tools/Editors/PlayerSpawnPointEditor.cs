﻿using Gameplay.Setup.Impl;
using UnityEditor;
using UnityEngine;

namespace Tools.Editors {
    [CustomEditor(typeof(PlayerSpawner))]
    [CanEditMultipleObjects]
    public class PlayerSpawnPointEditor : Editor {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(PlayerSpawner point, GizmoType gizmo) {
            Gizmos.color = new Color(0f, 1f, 0f, 0.75f);
            Gizmos.DrawSphere(point.Position, 1f);
        }
    }
}