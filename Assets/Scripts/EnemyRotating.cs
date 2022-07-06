using UnityEngine;

public class EnemyRotating : Enemy
{
  private Vector3 startPosition;
  private Vector3 currentDirection = Vector3.back;
  private int rotationCenterX = 2;
  
  protected override void StartMovement()
  {
    startPosition = gameObject.transform.position;
    InvokeRepeating("RotateEnemy", 0, 0.001f);
  }

  private void RotateEnemy()
  {
    if(!gameManager.isGameActive) return;
    if (gameObject.transform.position == startPosition)
    {
      currentDirection = currentDirection == Vector3.back ? Vector3.forward : Vector3.back;
      rotationCenterX *= -1;
    }
    gameObject.transform.RotateAround(new Vector3(rotationCenterX, 3, 0), currentDirection, 1);
  }
}