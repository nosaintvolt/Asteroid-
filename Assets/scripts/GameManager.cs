using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    public float respawnTime = 3.0f;
    public int lives = 5;
    public float respawnInulTime = 3.0f;
    public float score = 0;
    public void AsteroidDestroy(Asteroid asteroid){
      this.explosion.transform.position = asteroid.transform.position;
      this.explosion.Play();

      if(asteroid.size < 1.0f){
          this.score += 50f;
       } else if(asteroid.size < 2.0f){
          this.score += 25f;
       } else if(asteroid.size < 3.0f){
          this.score += 10f;
       }

    }
   public void PlayerDied() 
    {
       this.explosion.transform.position = this.player.transform.position;
       this.explosion.Play();

       this.lives-- ;
       if(this.lives <=0){
           GameOver();
       }else{
        Invoke(nameof(Respawn),this.respawnTime);}
    }
    private void Respawn(){
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer =  LayerMask.NameToLayer("Collisions Ignore");
        this.player.gameObject.SetActive(true);
        
        
        Invoke(nameof(TurnOnCollissions), this.respawnInulTime);
    }

    private void TurnOnCollissions(){
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    private void GameOver(){
        this.lives =5;
        this.score =0;

         Invoke(nameof(Respawn),this.respawnTime);
    }

}
