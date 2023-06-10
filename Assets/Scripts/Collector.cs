using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private Text kiwisCount;

    private int kiwis = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Kiwi"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            kiwis++;
            kiwisCount.text = "Kiwis collected: " + kiwis;
        }
    }
}
