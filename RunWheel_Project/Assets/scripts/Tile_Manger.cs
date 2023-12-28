using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Manger : MonoBehaviour
{
    public GameObject[] tile_prefabs;
    public float zspawn=0;
    public float tile_leangth=30;
    public int numberoftile = 6;
    public Transform PlayerTransform;
    public List<GameObject> gameObjects = new List<GameObject>();
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < numberoftile; i++)
        {
            if (i == 0)
            {
                spawnTile(0);
            }
            else
                spawnTile(Random.Range(0, tile_prefabs.Length));

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform.position.z-20 > zspawn- (numberoftile * tile_leangth))
        {

            spawnTile(Random.Range(0, tile_prefabs.Length));
            Destroy(gameObjects[0]);
            gameObjects.RemoveAt(0);
         
        }
        
    }

    public void spawnTile(int indexTile)
    {
        GameObject go= Instantiate(tile_prefabs[indexTile],transform.forward*zspawn,transform.rotation);
        gameObjects.Add(go);
        zspawn += tile_leangth;
    }
}
