using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
   
    public float rate;
    private int collisionCount=0;

    public AudioClip start;
    public AudioClip end;

    public AudioSource musicSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        musicSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(collisionCount == 0)
        {

           
            
                if (this.transform.localScale.x < 1)
                    this.transform.localScale = new Vector3(transform.localScale.x + (rate * Time.deltaTime), transform.localScale.y, transform.localScale.y);
            
               
            
        }

    }
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.transform.localScale.x > 0)
                this.transform.localScale = new Vector3(transform.localScale.x - (rate * Time.deltaTime), transform.localScale.y, transform.localScale.y);
            collisionCount = 1;
            
            musicSrc.clip = start;
            if(!musicSrc.isPlaying)
            musicSrc.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionCount = 0;
        musicSrc.clip = end;
        musicSrc.Play();
    }
}
