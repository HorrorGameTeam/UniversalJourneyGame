using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mortality : MonoBehaviour
{
     [SerializeField]
      private int hp = 100;
      public GameObject dieOverlay;


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

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Damager"))
        {
            takeDamage(10);
        }
    }
}


