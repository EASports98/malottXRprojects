using UnityEngine;
using UnityEngine.XR;
/*
select to spawn
where to object spawns
cooldown period
input - button
hand
*/

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; //Object to spawn
    public Transform spawnPoint; //Where it spawns
    public XRNode controllerNode = XRNode.RightHand;
    public float spawnCooldown = 1.0f; //Need coroutine
    private bool canSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
