using UnityEngine;

public class EnemyShaking : Enemy
{
  public bool clockwise;

  private Vector3[] directions = { Vector3.up, Vector3.up + Vector3.right, 
                                   Vector3.right, Vector3.right + Vector3.down,
                                   Vector3.down, Vector3.down + Vector3.left, 
                                   Vector3.left, Vector3.left + Vector3.up };
  private int directionIndex; 

  protected override void StartMovement()
  {
    InvokeRepeating("ShakeEnemy", 0, 0.25f);
  }
  
  void ShakeEnemy()
  {
    if(!gameManager.isGameActive) return;
    SelectDirection();
    gameObject.transform.Translate(directions[directionIndex] * 0.5f);
  }

  private void SelectDirection()
  {
    if (clockwise)
    {
      directionIndex++;
      if (directionIndex == directions.Length)
        directionIndex = 0;
    }
    else
    {
      directionIndex--;
      if (directionIndex < 0)
        directionIndex = directions.Length - 1;
    }
  }
}