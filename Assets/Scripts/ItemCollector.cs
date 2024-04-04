using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Apple = 0;
    private PlayerLife playerlife;

    [SerializeField] private Text AppleText;

    [SerializeField] private AudioSource CollectSoundEffect;

    private GameObject[] heartArray;

    private void Start()
    {
        playerlife = FindObjectOfType<PlayerLife>();
        heartArray = playerlife.GetHeartArray();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            CollectSoundEffect.Play();
            Destroy(collision.gameObject);
            Apple++;
            AppleText.text = "Apple: " + Apple;
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            playerlife.Life++;

            if (heartArray != null && heartArray.Length > 0 && playerlife.Life <= heartArray.Length)
            {
                heartArray[heartArray.Length - playerlife.Life].SetActive(false);
            }
        }
    }
}
