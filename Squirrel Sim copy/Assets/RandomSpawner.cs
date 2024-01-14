using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject acornPrefab;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;

    void Start()
    {
        // Check if tree game objects are properly assigned
        if (tree1 == null || tree2 == null || tree3 == null)
        {
            Debug.LogError("One or more tree game objects are not assigned!");
            return;
        }

        StartCoroutine(AcornSpawn());

    }

    IEnumerator AcornSpawn()
    {
        while (true)
        {
            GameObject randomTree = GetRandomTree();

            if (randomTree != null)
            {
                Vector3 randomTreePosition = randomTree.transform.position;

                // spawn ground
                Vector3 randomSpawnPosition = new Vector3(
                    Random.Range(-2*randomTreePosition.x, 2*randomTreePosition.x),
                    0.3f,
                    Random.Range(-2*randomTreePosition.z, 2*randomTreePosition.z)
                );

                GameObject newAcorn = Instantiate(acornPrefab, randomSpawnPosition, Quaternion.identity);
                Destroy(newAcorn, 10.0f);

                // spawn on tree
                float theta = Random.Range(0,2*3.0f);
                Vector3 randomSpawnPosition1 = new Vector3(
                    randomTreePosition.x + 15.3f * Mathf.Cos(theta),
                    Random.Range(0,randomTreePosition.y),
                    randomTreePosition.z + 15.3f * Mathf.Sin(theta)
                );
                GameObject newAcorn1 = Instantiate(acornPrefab, randomSpawnPosition1, Quaternion.identity);
                Destroy(newAcorn1, 10.0f);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }


    GameObject GetRandomTree()
    {
        GameObject[] trees = new GameObject[] { tree1, tree2, tree3 };

        int randomIndex = Random.Range(0, trees.Length);

        return trees[randomIndex];
    }
}