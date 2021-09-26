using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontrolBola2 : MonoBehaviour
{
    public int force;
    Rigidbody2D rb;
    
    private int score;
    public Text scoreText;

    GameObject panelSelesai;
    GameObject panelGameover;

    public int nyawa = 3;
    public int damage = 1;
    public GameObject[] hearts;

    AudioSource audio;
    public AudioClip soundHit;
    public AudioClip hitPaddle;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 3).normalized;
        rb.AddForce(arah * force);
        score = 0;
        SetScoreText();

        panelSelesai = GameObject.Find("PanelSelesai2");
        panelSelesai.SetActive(false);
        panelGameover = GameObject.Find("PanelGameover2");
        panelGameover.SetActive(false);

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll) 
    {
        audio.PlayOneShot(soundHit);
        if (coll.gameObject.name == "TepiBawah")//untuk reset bola bila kena tepi bawah
        {
            transform.localPosition = new Vector2(0, -3);
            rb.velocity = new Vector2(0, 0);
            Vector2 arah = new Vector2(0, 3).normalized;
            rb.AddForce(arah * force);
            TakeDamage();
        }

        if (coll.gameObject.name == "Paddle")
        {
            audio.PlayOneShot(hitPaddle);
            float sudut = (transform.position.x - coll.transform.position.x) * 5f;
            Vector2 arah = new Vector2(sudut, rb.velocity.y).normalized;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(arah * force * 2);
        }

        if (coll.gameObject.CompareTag("Block"))
        {
            coll.gameObject.SetActive(false);
            score = score + 10;
            SetScoreText();
        }

        if (score == 100)
        {
            panelSelesai.SetActive(true);
            Destroy(gameObject);
            return;
        }
    }
    void SetScoreText()
    {
        scoreText.text = " " + score.ToString();
    }

    public void TakeDamage() //untuk nyawa
    {
        nyawa -= damage;
        if (nyawa < 1)
        {
            Destroy(hearts[0].gameObject);
        }else if (nyawa < 2)
        {
            Destroy(hearts[1].gameObject);
        }else if (nyawa < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        
        if (nyawa == 0)
        {
            panelGameover.SetActive(true);
            Destroy(gameObject);
            return;
        }
    }
}

