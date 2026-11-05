using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] private InputActionReference spawnAction;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform spawnPoint;

    private void OnEnable()
    {
        if (spawnAction == null || spawnAction.action == null)
        {
            Debug.LogError($"{nameof(ObjectSpawn)} : aucune action assignee au champ Spawn Action.", this);
            return;
        }

        spawnAction.action.performed += SpawnCube;
        spawnAction.action.Enable();
    }

    private void OnDisable()
    {
        if (spawnAction == null || spawnAction.action == null)
            return;

        spawnAction.action.performed -= SpawnCube;
        spawnAction.action.Disable();
    }

    private void SpawnCube(InputAction.CallbackContext context)
    {
        if (cubePrefab == null)
        {
            Debug.LogError($"{nameof(ObjectSpawn)} : aucun prefab assigne au champ Cube Prefab.", this);
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError($"{nameof(ObjectSpawn)} : aucun Transform assigne au champ Spawn Point.", this);
            return;
        }

        Instantiate(cubePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
