using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTrigger : MonoBehaviour
{
    private MoveDragon dragonTrigger;
    [SerializeField] AudioSource roarSound;

    void Start()
    {
        dragonTrigger = GameObject.Find("Dragon").GetComponent<MoveDragon>();
    }
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            dragonTrigger.isDragonActivate = true;
            roarSound.Play();
        }
    }
}
