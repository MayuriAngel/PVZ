using UnityEngine;
public class Shovel : Plant
{
    public float damage;

    private float timer;
    public bool IsZombie = false;
    public bool isDie;
    private bool DPlant = true;

    private void Awake()
    {
        IsPlant = false;
        
      
    }
    protected override void Start()
    {
       
        base.Start();




}
   
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {

            IsZombie = true;
            
            animator.SetBool("IsZombie", true);
            other.GetComponent<ZombieNormal>().ChangeHealth(-damage);

        }
        if (other.CompareTag("Plant")&&DPlant == true)
        {
           
                Destroy(other.gameObject);
           DPlant = false;
           
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Zombie"))
        {
            animator.SetBool("IsZombie", true);
            collision.GetComponent<ZombieNormal>().ChangeHealth(-damage);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsZombie = false;
        animator.SetBool("IsZombie", false);
    }
}
