using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    private float coolDown = 0f;


    private void Update()
    {
        //getting the gamemanager.instance in a variable here so we don't need to keep typing it everytime. a good programer is a lazy programer
        var gameManager = GameManager.Instance;

        //this line will prevent the lines beneath it from executing in case the variable isGameOver is true.
        if (gameManager.isGameover()) { return; }
        
        coolDown -= Time.deltaTime;

        if(coolDown <= 0f)
        {
            //reseting the cooldown
            coolDown = gameManager.obstacleInterval;

            //spawnObstacle
            //first select randomly one of the prefabs on the list, we get the index with random.range, than we get the gameobject based on that index.
            int ObstaclePrefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[ObstaclePrefabIndex];

            //then we get the position where we want to spawn the obstacle, we need a vector 3 for that.
            float x = gameManager.obstacleOffSetX;
            float y = Random.Range(gameManager.obstacleOffSety.x, gameManager.obstacleOffSety.y);
            float z = 8.01f;
            Vector3 position = new Vector3(x,y,z);

            //then we need the rotation, in this case rotation is 0;
            Quaternion rotation = prefab.transform.rotation;
            
            // then we use the instantiate function to spawn the object, we need to pass the gameobject, the postion and the rotation that we want to spawn
            Instantiate(prefab, position, rotation);

        }
    }
}
