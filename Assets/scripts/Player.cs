using UnityEngine;


public class Player : MonoBehaviour
{ 
    public Bullet bulletPrefab;
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;

  private Rigidbody2D _rigibody;
  private bool _trusting;
  private float _turnDirection;
  private void Awake()
  {
      _rigibody = GetComponent<Rigidbody2D>();

  }

    private void Update()
    {

     _trusting= Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        
     if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
     _turnDirection = 1.0f;
     } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
        _turnDirection = -1.0f;
     } else {
        _turnDirection = 0.0f;
   
       }
     if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
        Shoot();
      }
     
    }
     
    private void FixedUpdate(){
        if (_trusting){ 
            _rigibody.AddForce(this.transform.up *this.thrustSpeed);
        }
        if(_turnDirection != 0.0f){
          _rigibody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }
    
    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab,this.transform.position,this.transform.rotation);
        
        bullet.Project(this.transform.up);
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.gameObject.tag =="Asteroid")
         {
             _rigibody.velocity = Vector3.zero;
             _rigibody.angularVelocity = 0.0f;

             this.gameObject.SetActive(false);

             FindObjectOfType<GameManager>().PlayerDied();
         }
     }


}




