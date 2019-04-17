// MeshSelector
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshSelector : MonoBehaviour
{
	public Mesh[] Meshes;

	public void SelectMesh(int index)
	{
		GetComponent<MeshFilter>().mesh = Meshes[index];
	}
}
