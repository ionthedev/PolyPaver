using System.Collections.Generic;
using Godot;

namespace PolyPaver;

[Tool]
public partial class Test2 : Node
{
    ArrayMesh arrayMesh;
    MeshInstance3D[] vertexObjects = new MeshInstance3D[4];
    Vector3[] vertices = new Vector3[4];
    [Export] private ShaderMaterial mat = new ShaderMaterial();
    
    public override void _Ready()
    {
        // Create the ArrayMesh and a surface for it
        arrayMesh = new ArrayMesh();
        var arrays = new Godot.Collections.Array();
        arrays.Resize((int)Godot.Mesh.ArrayType.Max);

        // Define initial vertices
        vertices = new Vector3[]
        {
            new Vector3(-1, 0, -1),
            new Vector3(1, 0, -1),
            new Vector3(1, 0, 1),
            new Vector3(-1, 0, 1)
        };

        // Define indices
        var indices = new int[]
        {
            0, 1, 2, // Triangle 1
            2, 3, 0  // Triangle 2
        };

        // Set the vertices and indices
        arrays[(int)Godot.Mesh.ArrayType.Vertex] = vertices;
        arrays[(int)Godot.Mesh.ArrayType.Index] = indices;

        // Create the mesh
        arrayMesh.AddSurfaceFromArrays(Godot.Mesh.PrimitiveType.Triangles, arrays);

        // Create movable objects at each vertex
        for (int i = 0; i < vertices.Length; i++)
        {
            var vertexObject = new MeshInstance3D();
            vertexObject.Name = $"Vertex_{i}";
            vertexObject.Mesh = new BoxMesh(); // For visualization
            vertexObject.Scale = new Vector3(0.1f, 0.1f, 0.1f); // Make it small
            vertexObject.Position = vertices[i];

            // Ensure it's selectable in the editor
            vertexObject.SetMeta("selectable", true);

            AddChild(vertexObject);
            vertexObjects[i] = vertexObject;

            // Optionally, make this MeshInstance always visible in the editor,
            // even if its parent is hidden
            vertexObject.Owner = this;
        }

        // Create a MeshInstance for displaying the quad mesh
        var meshInstance = new MeshInstance3D();
        meshInstance.Mesh = arrayMesh;
        arrayMesh.SurfaceSetMaterial(0, mat);
        AddChild(meshInstance);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Engine.IsEditorHint())
        {
            // Check if the vertex objects have moved, and update the mesh accordingly
            bool updated = false;
            for (int i = 0; i < vertexObjects.Length; i++)
            {
                if (vertexObjects[i].Position != vertices[i])
                {
                    vertices[i] = vertexObjects[i].Position;
                    updated = true;
                }
            }

            UpdateMesh();
        }
    }

    void UpdateMesh()
    {
        if (!Engine.IsEditorHint() && Engine.IsEditorHint()) return;
        arrayMesh.ClearSurfaces();
        var arrays = new Godot.Collections.Array();
        arrays.Resize((int)Godot.Mesh.ArrayType.Max);
        arrays[(int)Godot.Mesh.ArrayType.Vertex] = vertices;

        // Re-define indices (same as before)
        var indices = new int[]
        {
            0, 1, 2,
            2, 3, 0
        };
        arrays[(int)Godot.Mesh.ArrayType.Index] = indices;
        arrayMesh.AddSurfaceFromArrays(Godot.Mesh.PrimitiveType.Triangles, arrays);
    }
}