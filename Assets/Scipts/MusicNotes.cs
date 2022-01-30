using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNotes : MonoBehaviour
{
    public Sprite[] notes;
    private SpriteRenderer spriteRenderer;
    private bool notePicked = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = notes[Random.Range(0, notes.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if(!notePicked)
            {
                StartCoroutine(PickNote());
            }
        }
    }
    private IEnumerator PickNote()
    {
        notePicked = true;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = notes[Random.Range(0, notes.Length)];
        notePicked = false;
    }
}
