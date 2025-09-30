using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem.XR; // For communicating with quest controllers
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
    public XRNode controllerNode = XRNode.RightHand; //Assigning right hand controller
    public float spawnCooldown = 1.0f; //Need coroutine
    private bool canSpawn = true; //Time in seconds between spawns


    // Update is called once per frame
    void Update()
    {
        if (canSpawn && IsAButtonPressed())
        {
            StartCoroutine(SpawnObjectWithCooldown());
        }
    }

    bool IsAButtonPressed()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);
        bool buttonPressed = false;

        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPressed) && buttonPressed) //Primary button is "a" or "x" on oculus controller
        {
            return true;
        }

        return false;
    }

    IEnumerator SpawnObjectWithCooldown()
    {
        canSpawn = false; //Prevents immediate respawning
        SpawnObject();
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true; //ALlows us to spawn again
       
    }

    void SpawnObject()
    {
        if (objectPrefab != null && spawnPoint != null)
        {
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        else
        {
            Debug.LogError("Assign objectPrefab and spawnPoint in the inspector.");
        }
    }
}
