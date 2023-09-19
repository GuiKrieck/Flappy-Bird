using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private void FixedUpdate()
    {
        //getting the gamemanager.instance in a variable here so we don't need to keep typing it everytime. a good programer is a lazy programer
        var gameManager = GameManager.Instance;

        //this line will prevent the lines beneath it from executing in case the variable isGameOver is true.
        if (gameManager.isGameover()) { return; }

        //move the obstacles
        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);


        //destroy obstacles
        if(transform.position.x <= -gameManager.obstacleOffSetX)
        {
            Destroy(gameObject);
        }
    }
}
