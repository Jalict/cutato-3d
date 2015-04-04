using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {
    public AudioClip collisionSound;
    private float lastPlayedSound;

    void Start() {
    }

    void OnCollisionEnter(Collision other)
    {
        //TODO Fix such that the sounds doesn't play all the freakin time

        float velocity = GetComponent<Rigidbody>().velocity.sqrMagnitude/5;

        if (velocity >= 1f) { 
            AudioSource.PlayClipAtPoint(collisionSound, transform.position, velocity);
        }
    }
}
