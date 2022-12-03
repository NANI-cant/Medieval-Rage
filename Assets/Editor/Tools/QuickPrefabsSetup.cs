using System;
using Extensions;
using Gameplay.Fighting;
using Gameplay.Health;
using Gameplay.Teaming;
using Gameplay.Utils;
using Network.Gameplay;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools {
    public class QuickPrefabsSetup {
        [MenuItem("GameObject/QuickSetup/Make Networked")]
        public static void MakeNetworked() {
            var gameObject = Selection.activeGameObject;
            if(gameObject == null) return;

            gameObject.AddComponentSingle<PhotonView>();
            gameObject.AddComponentSingle<GameObjectSync>();
            gameObject.AddComponentSingle<HealthSync>();
            gameObject.AddComponentSingle<PhotonTransformView>()
                .With(ptv => ptv.m_SynchronizePosition = true)
                .With(ptv => ptv.m_SynchronizeRotation = true)
                .With(ptv => ptv.m_SynchronizeScale = false)
                .With(ptv => ptv.m_UseLocal = true);
            
            var animator = gameObject.GetComponentInChildren<Animator>();
            animator.AddComponentSingle<AnimatorSync>();
            animator.AddComponentSingle<PhotonAnimatorView>()
                .With(pav => {
                    foreach (var parameter in pav.GetSynchronizedParameters()) {
                        parameter.SynchronizeType = PhotonAnimatorView.SynchronizeType.Discrete;
                    }
                });
        }
        
        [MenuItem("GameObject/QuickSetup/Enemy Avatar")]
        public static void EnemyAvatar() {
            var gameObject = Selection.activeGameObject;
            if(gameObject == null) return;

            DestroyAllMonoBehaviours(gameObject);

            gameObject.AddComponent<Health>();
            gameObject.AddComponent<AttackTargetPriority>();
            gameObject.AddComponent<Team>();
            gameObject.AddComponent<DestroyObserver>();
            gameObject.AddComponent<PhotonView>();
            gameObject.AddComponent<GameObjectSync>();
            gameObject.AddComponent<HealthSync>();
            gameObject.AddComponent<PhotonTransformView>()
                .With(ptv => ptv.m_SynchronizePosition = true)
                .With(ptv => ptv.m_SynchronizeRotation = true)
                .With(ptv => ptv.m_SynchronizeScale = false)
                .With(ptv => ptv.m_UseLocal = true);
                

            var animator = gameObject.GetComponentInChildren<Animator>();
            DestroyAllMonoBehaviours(animator.gameObject);
            
            animator.AddComponent<AnimatorSync>();
            animator.AddComponent<PhotonAnimatorView>()
                .With(pav => {
                    foreach (var parameter in pav.GetSynchronizedParameters()) {
                        parameter.SynchronizeType = PhotonAnimatorView.SynchronizeType.Discrete;
                    }
                });
        }

        private static void DestroyAllMonoBehaviours(GameObject gameObject) {
            var monoBehaviours = gameObject.GetComponents<MonoBehaviour>();
            int lastCount = monoBehaviours.Length;
            while (monoBehaviours.Length != 0) {
                DestroyMonoBehaviourRecursive(monoBehaviours[0]);
                monoBehaviours = gameObject.GetComponents<MonoBehaviour>();
                if (lastCount == monoBehaviours.Length) {
                    Debug.LogException(new Exception("Error infinity loop when destroying components"));
                    return;
                }
                lastCount = monoBehaviours.Length;
            }
        }

        private static void DestroyMonoBehaviourRecursive(MonoBehaviour destroyableMB) {
            if(destroyableMB == null) return;
            
            Type destroyableMBType = destroyableMB.GetType();
            var MBs = destroyableMB.GetComponents<MonoBehaviour>();
            foreach (var MB in MBs) {
                var requireComponentAttributes = MB.GetType().GetCustomAttributes(typeof(RequireComponent), false);
                foreach (var requireComponentAttribute in requireComponentAttributes) {
                    var currentRCA = requireComponentAttribute as RequireComponent;
                    if (currentRCA.m_Type0.IsAssignableFrom(destroyableMBType)) {
                        DestroyMonoBehaviourRecursive(MB); 
                    }
                }
            }
            Object.DestroyImmediate(destroyableMB);
        }
    }
}