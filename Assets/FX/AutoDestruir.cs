using UnityEngine;

public class AutoDestruir : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }
}
