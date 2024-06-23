using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject background;
    public float spawnRate;
    public Transform birdTranform;
    private float timer;
    private float backgroundWidth;
    private List<GameObject> backgorundObjects = new List<GameObject>();
    void Start()
    {
        backgroundWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        SpawnInitialBackgrounds();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate) 
        {
            SpawnPipe();
            timer = 0;
        }
        CheckAndSpawnBackgorund();
    }
    void SpawnPipe()
    {
        float yposition = Random.Range(-2, 2);
        Vector3 spawnPosition = new Vector3(birdTranform.position.x + 10, yposition, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

    }
    void SpawnBackground(float xPosition)
    {
        Vector3 spawnPosition = new Vector3(xPosition, 0, 0);
        GameObject newBackground = Instantiate(background, spawnPosition, Quaternion.identity);
        backgorundObjects.Add(newBackground);
    }
    void CheckAndSpawnBackgorund()
    {
        GameObject rightMostBackground = backgorundObjects[backgorundObjects.Count - 1];
        if (birdTranform.position.x + backgroundWidth > rightMostBackground.transform.position.x)
        {
            SpawnBackground(rightMostBackground.transform.position.x + backgroundWidth);
        }

        GameObject leftMostBackground = backgorundObjects[0];
        if (birdTranform.position.x - backgroundWidth > leftMostBackground.transform.position.x + backgroundWidth)
        {
            Destroy(leftMostBackground);
            backgorundObjects.RemoveAt(0);
        }

    }
    void SpawnInitialBackgrounds()
    {
        float startX = birdTranform.position.x;
        for (int i = -1; i <= 1; i++)
        {
            SpawnBackground(startX + i * backgroundWidth);
        }
    }
}
