
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float speed = 5.0f;
    public float maxLifetime = 20f;
    public float size = 2.0f;
    public float minSize = 1.0f;
    public float maxSize = 3.0f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigibody;





    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigibody = GetComponent<Rigidbody2D>();

    }
    
    private void Start()
    {
      _spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];

      this.transform.eulerAngles = new Vector3(0.0f,0.0f,Random.value * 360.0f);
      this.transform.localScale = Vector3.one * this.size;

      _rigibody.mass = this.size;
    }


    public void SetTrajectory(Vector2 direction)
    {
        _rigibody.AddForce(direction *this.speed);

        Destroy(this.gameObject,this.maxLifetime);
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Bullet"){
            if((this.size * 0.5f ) >= this.minSize){
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDestroy(this);
            Destroy(this.gameObject);
         }
        //if (collision.gameObject.tag == "Asteroid"){
        //  if((this.size * 0.5f ) >= this.minSize){
        //      CreateSplit();
        //     CreateSplit();
        // }
        //  FindObjectOfType<GameManager>().AsteroidDestroy(this);
        // Destroy(this.gameObject);
        // }
     }

    private void CreateSplit(){
       Vector2 position = this.transform.position;
       position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this,position,this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized);
    }

     
  

}
