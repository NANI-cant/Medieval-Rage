using System.Collections;
using UnityEngine;

namespace Architecture.Services {
    public interface ICoroutineRunner {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine coroutine);
    }
}