using Godot;
using System;

[Tool]
public partial class Test : MeshInstance3D
{
    
    private float _frequency;
    [Export] public float Frequency
    {
        get {return _frequency;}
        set
        {
            _frequency = value;
            DoThing(0);
        }
    }

    public override void _Ready()
    {
        DoThing(0);
    }


    public void DoThing(float delta)
    {

        var mdt = new MeshDataTool();
        var fnl = new FastNoiseLite();
        if(Engine.IsEditorHint() || !Engine.IsEditorHint())
        {
            var mesh = (ArrayMesh)this.Mesh;
            fnl.Frequency = _frequency * delta * 5;

            mdt.CreateFromSurface(mesh, 0); 

            for(int i = 0; i < mdt.GetVertexCount(); i++)
            {
                var vertex = mdt.GetVertex(i).Normalized();
                vertex = vertex * (fnl.GetNoise3Dv(vertex) * 0.5f + 0.75f);
                mdt.SetVertex(i, vertex);
            }

            for(int i = 0; i< mdt.GetFaceCount(); i++)
            {
                var a= mdt.GetFaceVertex(i, 0);
                var b= mdt.GetFaceVertex(i, 1);
                var c= mdt.GetFaceVertex(i, 2);

                var ap = mdt.GetVertex(a);
                var bp = mdt.GetVertex(b);
                var cp = mdt.GetVertex(c);

                var n = (bp - cp).Cross(ap - bp).Normalized();
                mdt.SetVertexNormal(a, n + mdt.GetVertexNormal(a));
                mdt.SetVertexNormal(b, n + mdt.GetVertexNormal(b));
                mdt.SetVertexNormal(c, n + mdt.GetVertexNormal(c));
            }

            for(int i = 0; i < mdt.GetVertexCount(); i++)
            {
                var v = mdt.GetVertexNormal(i).Normalized();
                mdt.SetVertexNormal(i, v);
                mdt.SetVertexColor(i, new Color(v.X, v.Y, v.Z));
            }

            mesh.ClearSurfaces();
            mdt.CommitToSurface(mesh);
        }
    }
}
