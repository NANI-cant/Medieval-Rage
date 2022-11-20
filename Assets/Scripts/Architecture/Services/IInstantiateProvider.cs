﻿using UnityEngine;

namespace Architecture.Services {
    public interface IInstantiateProvider {
        TObject Instantiate<TObject>(TObject template, Vector3 position, Quaternion rotation) where TObject : Object;
        TObject Instantiate<TObject>(TObject template, Vector3 position, Quaternion rotation, Transform parent) where TObject : Object;
    }
}