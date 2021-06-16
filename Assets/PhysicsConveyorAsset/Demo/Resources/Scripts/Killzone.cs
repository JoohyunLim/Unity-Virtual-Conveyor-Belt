using UnityEngine;

public class Killzone : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject, 3);
    }
}
