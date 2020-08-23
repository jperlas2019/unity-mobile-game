using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public GameObject cloud1;
    public GameObject cloud2;
    List<GameObject> cloud_array = new List<GameObject>();
    
    void Start()
    {
        spawn_clouds();
    }

    void Update()
    {
        cloud_array[0].transform.Translate(Vector3.left * Time.deltaTime * 2 );
        cloud_array[1].transform.Translate(Vector3.left * Time.deltaTime * 1 );
        cloud_array[2].transform.Translate(Vector3.left * Time.deltaTime * 1.5f);
        if(cloud_array[0].transform.position.x < -15)
        {
            reset_cloud(cloud_array[0]);
        }
        if(cloud_array[1].transform.position.x < -15)
        {
            reset_cloud(cloud_array[1]);
        }
        if(cloud_array[2].transform.position.x < -15)
        {
            reset_cloud(cloud_array[2]);
        }

    }
    public void spawn_clouds()
    {
        GameObject cloud_object1 = Instantiate(cloud1, new Vector3(565, Random.Range(172, 220), transform.position.z - 1), Quaternion.identity);
        cloud_object1.transform.localScale = new Vector3(55, 64, 46);
        cloud_object1.transform.SetParent(this.transform, false);
        cloud_array.Add(cloud_object1);

        GameObject cloud_object2 = Instantiate(cloud2, new Vector3(700, Random.Range(172, 220), transform.position.z - 1), Quaternion.identity);
        cloud_object2.transform.localScale = new Vector3(55, 64, 46);
        cloud_object2.transform.SetParent(this.transform, false);
        cloud_array.Add(cloud_object2);

        GameObject cloud_object3 = Instantiate(cloud2, new Vector3(700, Random.Range(172, 220), transform.position.z - 1), Quaternion.identity);
        cloud_object3.transform.localScale = new Vector3(53, 62, 44);
        cloud_object3.transform.SetParent(this.transform, false);
        cloud_array.Add(cloud_object3);
    }

    public void reset_cloud(GameObject cloud_object)
    {
        cloud_object.transform.position = new Vector3(Random.Range(12, 17), Random.Range(3.0f, 4.5f), transform.position.z - 1);
    }
    
}
