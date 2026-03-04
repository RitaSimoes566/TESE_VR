using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject area;

    Mesh areaMesh;

    public int enemyNumber = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        areaMesh = area.GetComponent<MeshFilter>().mesh;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        /*for (int i = 0; i < enemyNumber; i++)
        {*/
            float sizeX = areaMesh.bounds.size.x / 2;
            float sizeZ = areaMesh.bounds.size.z / 2;

            float posX = Random.Range(area.transform.position.x - sizeX, area.transform.position.x + sizeX);
            float posZ = Random.Range(area.transform.position.z - sizeZ, area.transform.position.z + sizeZ);

            enemy.transform.position = new Vector3(posX, area.transform.position.y, posZ);
        /*}*/
        
    }
}
