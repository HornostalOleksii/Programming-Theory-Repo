using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
  private float horizontalInput;
  private float verticalInput;
  public float speed = 15.0f;
  public float xRange = 10;
  public float yRange = 1;
  public List<GameObject> bulletsPrefabs;
  private int bulletPrefabIndex = 0;
  
  void Update()
  {
    horizontalInput =  Input.GetAxis("Horizontal");
    verticalInput =  Input.GetAxis("Vertical");
    transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        
    if (transform.position.x < -xRange)
    {
      transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
    }
    else if (transform.position.x > xRange)
    {
      transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
    }        
        
    if (transform.position.y < -yRange)
    {
      transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
    }
    else if (transform.position.y > yRange)
    {
      transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
    }

    if (Input.GetKeyDown(KeyCode.Space))
    {
      Instantiate(bulletsPrefabs[bulletPrefabIndex], transform.position, bulletsPrefabs[bulletPrefabIndex].transform.rotation);
    }

    if (Input.GetKeyDown(KeyCode.X))
    {
      bulletPrefabIndex++;
      if (bulletPrefabIndex > bulletsPrefabs.Count - 1)
        bulletPrefabIndex = 0;
    }
  }
}