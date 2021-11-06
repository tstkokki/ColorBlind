using UnityEngine;

public class StoreSpawnPoint : MonoBehaviour
{
    [SerializeField] VectorThree_SO spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint.Set(transform.position + Vector3.up);
    }

}
