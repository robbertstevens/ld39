using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    // Use this for initialization

    public GameObject FloorGameObject;
    public GameObject WallGameObject;
    public int Height = 24;
    public int Width = 32;

    void Start()
    {
        for (int x = -16; x < Width / 2; x++)
        {
            for (int y = -12; y < Height / 2; y++)
            {
                GameObject go;
                if (x == -(Width / 2) || x == (Width / 2) -1 || y == -(Height / 2) || y == (Height / 2) -1)
                {
                    go = Instantiate(WallGameObject, new Vector2(x, y), Quaternion.identity) as GameObject;
                }
                else
                {
                    go = Instantiate(FloorGameObject, new Vector2(x, y), Quaternion.identity) as GameObject;
                }
                go.name = string.Format("pos|{0}|{1}", x, y);

                go.transform.parent = this.transform;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
