using UnityEngine;

public class BoxMaterialPicker : MonoBehaviour {

    [SerializeField] private Material[] materials;
    [SerializeField] private Vector2 scaleModifier;

	private void Start ()
    {
        GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
        transform.localScale = new Vector3(transform.localScale.x * Random.Range(scaleModifier.x, scaleModifier.y), transform.localScale.y * Random.Range(scaleModifier.x, scaleModifier.y), transform.localScale.z * Random.Range(scaleModifier.x, scaleModifier.y));
	}
}
