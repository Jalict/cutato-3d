using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour {
    public AudioClip audioGlitch;

    void OnCollisionEnter(Collision other)
    {
        float velocity = GetComponent<Rigidbody>().velocity.sqrMagnitude / 5;

        if (velocity >= 1f)
        {
            //AudioSource.PlayClipAtPoint(audioGlitch, transform.position);
        }
    }
}
