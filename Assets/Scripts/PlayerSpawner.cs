using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Vector3 startingPosition = new Vector3(-11.81f, 2.05f, 8.38f);

    private void Start()
    {
        int playerPrefabIndex = Random.Range(0, GameManager.Instance.playerPrefabs.Count);
        GameObject Player = GameManager.Instance.playerPrefabs[playerPrefabIndex];

        Instantiate(Player, startingPosition, transform.rotation);
    }
}
