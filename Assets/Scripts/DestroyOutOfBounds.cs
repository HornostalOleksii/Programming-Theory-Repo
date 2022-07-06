using System;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
  private float topBound = 10;

  private float lowerBound = -10;
  private GameManager gameManager;

  private void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.y > topBound)
    {
      Destroy(gameObject);
    }
    else if (transform.position.y < lowerBound)
    {
      gameManager.GameOver();
      Destroy(gameObject);
    }
  }
}