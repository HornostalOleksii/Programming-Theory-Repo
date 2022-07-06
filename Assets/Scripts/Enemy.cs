using UnityEngine;

public class Enemy : MonoBehaviour
{
  protected GameManager gameManager;

  private void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    StartMovement();
  }

  protected virtual void StartMovement()
  {
  }

  private void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player"))
    {
      gameManager.GameOver();
    }
    else if (other.CompareTag("Bullet"))
    {
      gameManager.UpdateScore(1);
      Destroy(gameObject);
      Destroy(other.gameObject);
    }
  }
}