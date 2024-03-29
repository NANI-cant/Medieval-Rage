﻿using Gameplay.Setup.Impl;
using UnityEditor;
using UnityEngine;

namespace Tools.Editors {
    [CustomEditor(typeof(EnemySpawner))]
    [CanEditMultipleObjects]
    public class EnemySpawnPointEditor : Editor {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(EnemySpawner point, GizmoType gizmo) {
            Gizmos.color = new Color(1f, 0f, 0f, 0.75f);
            Gizmos.DrawSphere(point.Position, 1f);
        }
    }
}