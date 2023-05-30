using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class Mortality : MonoBehaviour
{

     [SerializeField]
      private int hp = 100;
      public GameObject dieOverlay;
    public TextMeshProUGUI hp_text;
    public AudioClip deathSound;
    private AudioSource _audioSource;

    
        

      public bool Alive()
    {
        return hp > 0;
    }

    private void Awake()
    {
        dieOverlay.SetActive(false);
    }

      private void Die()
    {
        Debug.Log("You Died");
        GetComponent<Animator>().SetBool("Die2", true);
        GameObject.FindObjectOfType<PlayerController>().enabled = false;
        GameObject.FindObjectOfType<CameraController>().enabled = false;
        dieOverlay.SetActive(true);
        hp = 0;
        _audioSource.clip = deathSound;
        _audioSource.Play();

        
    }

    public void takeDamage(int damage)
    {
        if(hp> damage)
        {
            Debug.Log("You are getting damaged" + damage);
            hp -= damage;
        }
        else
        {
            if(Alive())
            {
                Die();
            }
        }
        hp_text.text = hp.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Damager"))
        {
            takeDamage(2);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


}


