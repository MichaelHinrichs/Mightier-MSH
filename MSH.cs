//Written for Mightier. https://store.steampowered.com/app/29150
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Mightier_MSH
{
    public class MSH
    {
        private readonly List<Vector3> points = new();
        private readonly List<Vector3> normals = new();
        private readonly List<Vector2> uvs = new();
        private readonly List<Vector3> bones = new();
        private readonly List<Vector3> faces = new();
        private static MSH Read(string mshFile)
        {
            BinaryReader br = new(File.OpenRead(mshFile));
            if (new string(br.ReadChars(4)) != "BOD\0")
                throw new System.Exception("This is not a Mightier msh file.");

            br.ReadInt32();//Version?
            MSH msh = new();

            int pointCount = br.ReadInt32();
            for (int i = 0; i < pointCount; i++)
            {
                msh.points.Add(new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
                msh.normals.Add(new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
                br.ReadInt32();//Unknown. Always either -1, or 0.
                msh.uvs.Add(new Vector2(br.ReadInt32(), br.ReadInt32()));
            }

            int boneCount = br.ReadInt32()
            for (int i = 0; i < boneCount; i++)
                msh.bones.Add(new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));

            int faceCount = br.ReadInt32();
            for (int i = 0; i < faceCount / 3; i++)
                msh.faces.Add(new Vector3(br.ReadInt16(), br.ReadInt16(), br.ReadInt16()));

            return msh;
        }
    }
}
