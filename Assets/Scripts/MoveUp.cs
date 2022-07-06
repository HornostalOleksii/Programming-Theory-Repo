using UnityEngine;

public class MoveUp : MonoBehaviour
{
  protected GameManager gameManager;
  public float speed = 10.0f;

  private void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }
  // Update is called once per frame
  void Update()
  {
    if(CompareTag("Enemy") && !gameManager.isGameActive) return;
    transform.Translate(Vector3.up * speed * Time.deltaTime);
  }
}