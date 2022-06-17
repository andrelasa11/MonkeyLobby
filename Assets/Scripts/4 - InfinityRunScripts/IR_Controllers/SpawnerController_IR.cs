using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController_IR : MonoBehaviour
{

    [Header("Cadence")]
    [SerializeField] private float initialWaitTime; // tempo de espera para iniciar o spawn
    [SerializeField] private float cadence; // tempo de espera entre um objeto e outro

    [Header("SpawnLocation")]
    [SerializeField] private float xPosition;
    [SerializeField] private float yMinPosition;
    [SerializeField] private float yMaxPosition;

    [Header("Dependencies")]
    [SerializeField] private List<GameObject> objectsForSpawn;

    //private
    private int objIndex;
    private Vector3 objPosition;
    private Quaternion spawnRotation = new Quaternion(0, 0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    #region "Coroutines"

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(initialWaitTime);

        while (true)
        {

            objIndex = Random.Range(0, objectsForSpawn.Count);
            objPosition.y = Random.Range(yMinPosition, yMaxPosition);
            objPosition.x = xPosition;

            Instantiate(objectsForSpawn[objIndex], objPosition, spawnRotation);

            yield return new WaitForSeconds(cadence);
        }

    }

    #endregion
}
