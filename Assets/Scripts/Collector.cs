using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    private int kiwis = 0;
    [SerializeField] private Text kiwisCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Kiwi"))
        {
            Destroy(collision.gameObject);
            kiwis++;
            kiwisCount.text = "Kiwis collected: " + kiwis;
        }
    }
}
