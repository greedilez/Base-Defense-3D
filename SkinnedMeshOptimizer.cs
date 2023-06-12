using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class SkinnedMeshOptimizer : MonoBehaviour
{
    [SerializeField] private float _quality = 1;

    private SkinnedMeshRenderer _skinnedMeshRenderer;

    private void Awake() {
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        OptimizeMeshFast();
    }

    public void OptimizeMesh() {
        var meshSimplifier = new UnityMeshSimplifier.MeshSimplifier();
        meshSimplifier.Initialize(_skinnedMeshRenderer.sharedMesh);
        meshSimplifier.SimplifyMesh(_quality);
        var targetMesh = meshSimplifier.ToMesh();
        _skinnedMeshRenderer.sharedMesh = targetMesh;
    }

    public void OptimizeMeshFast() => _skinnedMeshRenderer.sharedMesh.Optimize();
}
