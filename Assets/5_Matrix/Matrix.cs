using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    private Matrix4x4 worldMat;
    void Start()
    {
        MakeWorldMatrix();
        //ExtractionMatrix();
    }

    void MakeWorldMatrix()
    {
        Quaternion rot = Quaternion.Euler(45, 0, 45);
        Vector3 tran = new Vector3(2, 1, 5);
        Vector3 scal = new Vector3(10, 10, 10);
        worldMat = Matrix4x4.TRS(tran, rot, scal);
        //worldMat = Matrix4x4.Translate(new Vector3(2, 1, 5)) * Matrix4x4.Rotate(rot) * Matrix4x4.Scale(new Vector3(10,10,10));
        
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(worldMat.GetRow(i));
        }
    }
    private void ExtractionMatrix()
    {
        Matrix4x4 matrix = transform.localToWorldMatrix; // localToWorld Matrix를 저장하겠다. TRS == localToMatrix
        Debug.Log("=== Extraction Matrix ===");
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(matrix.GetRow(i));
        }

        Vector3 position = matrix.GetColumn(3);
        Debug.Log("=== Position ===");
        Debug.Log(position);

        Quaternion rotation = Quaternion.LookRotation(
            matrix.GetColumn(2),
            matrix.GetColumn(1)
        );

        Debug.Log("=== Rotation ===");
        Debug.Log(rotation.eulerAngles);

        Debug.Log("=== Scale ===");
        Vector3 scale = new Vector3(
            matrix.GetColumn(0).magnitude,
            matrix.GetColumn(1).magnitude,
            matrix.GetColumn(2).magnitude
        );
        Debug.Log(scale);
    }
}
