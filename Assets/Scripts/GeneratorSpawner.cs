﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSpawner : MonoBehaviour
{

    private int Width;
    private int Height;

    public float GeneratorSpawnPeriod;
    void Awake()
    {
        MapGenerator map = GetComponent<MapGenerator>();

        Height = map.Height;
        Width = map.Width;

        StartCoroutine(SpawnGenerator());
    }

    private IEnumerator SpawnGenerator()
    {
        while (true)
        {
            int x = Random.Range(-(Width / 2) + 1, (Width / 2) - 2);
            int y = Random.Range(-(Height / 2) + 1, (Height / 2) - 2);
            Instantiate(Resources.Load("Prefabs/Generator"), new Vector2(x, y), Quaternion.identity);
            yield return new WaitForSecondsRealtime(GeneratorSpawnPeriod);
        }
    }
}
