using Godot;
using Godot.Collections;
using Godot.NativeInterop;
using Microsoft.VisualBasic;
using System;
using System.Linq;

public partial class Mesh : Resource
{

    #region Vertices

    [Export] public Vector3[] vertices;
    [Export] public int[] vertex_edges;
    [Export] public Color[] vertex_colors;

    #endregion

    #region Edges
    [Export] public int[] edge_vertices;
    [Export] public int[] edge_faces;
    [Export] public int[] edge_edges;
    #endregion

    #region Faces
    [Export] public int[] face_edges;
    [Export] public int[] face_surfaces;
    [Export] public Color[] face_colors;
    #endregion

    public void CreateTriangle()
    {
        ArrayMesh t = new ArrayMesh();
        t.ClearSurfaces();
    }
}
