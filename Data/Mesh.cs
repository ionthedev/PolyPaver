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

    public int vertice_count()
    {
        return vertices.Length;
    }

    public Vector3 vertex(int i)
    {
        return vertices[i];
    }

    public Vector3 vertex_normal(int v_i)
    {
        var faces = get_vert_faces(v_i);
        var normal = Vector3.Zero;
        foreach(var f in faces)
        {
            normal += face_normal(f);
        }
        normal /= faces.Length;
        return normal;
    }
    public int edge_count()
    {
        return edge_vertices.Length / 2;
    }
    public Array edge(int i)
    {
        return [edge_origin(i), edge_destination(i)];
    }
    public Vector3 edge_normal(int e)
    {
        var face_normal_left = face_normal(edge_face_left(e));
        var face_normal_right = face_normal(edge_face_right(e));
        return(face_normal_left + face_normal_right) / 2;
    }

    public int face_count()
    {
        return face_edges.Length;
    }

    public Vector3[] face_vertices(int idx)
    {
        var vert_idxs = face_vertex_indexes(idx);
        Vector3[] verts = new Vector3[0];
        foreach(var v_idx in vert_idxs)
        {
            verts.push_back(vertices[v_idx]);
        }
        return verts;
    }
}
