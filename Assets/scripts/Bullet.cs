using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public float speed = 500.0f;
    public float maxLifetime = 5.0f;
    private Rigidbody2D _rigibody;
  private void Awake ()
  {
   _rigibody = GetComponent<Rigidbody2D>();

  }
  public void Project(Vector2 direction)
   {
      _rigibody.AddForce(direction * this.speed);
      Destroy(this.gameObject,this.maxLifetime);
   }
   private void OnCollisionEnter2D(Collision2D collision)
   {
       Destroy(this.gameObject);
   }

} 
