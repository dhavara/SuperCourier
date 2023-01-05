using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TMP_Text ScoreTxt;
    public GameObject panelGameOver;

    private Rigidbody2D rb;

    bool isGrounded = false;
    bool isAlive = true;
    int Score;

    public GlobalVariable global;

    public AudioSource Cherry;
    public AudioSource Jump;
    public AudioSource Dead;
    public AudioSource bgSong;

    public int getPlayerScore()
    {
        return Score;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Score = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            float hDirection = Input.GetAxis("Horizontal");

            //! Jika menekan key A maka rigidbody bergerak ke kiri.
            // if(Input.GetKey(KeyCode.A)) -> switched key to using unity Input GetAxis.
            if (hDirection < 0)
            {
                //! bergerak ke kiri dengan speed 5.
                rb.velocity = new Vector2(-5, rb.velocity.y);

                //! flip sprite menghadap kiri saat menekan A.
                transform.localScale = new Vector2(-1, 1);
            }

            //! Jika menekan key D maka rigidbody bergerak ke kanan.
            // else if (Input.GetKey(KeyCode.D)) -> switched key to using unity Input GetAxis.
            else if (hDirection > 0)
            {
                //! bergerak ke kanan dengan speed 5.
                rb.velocity = new Vector2(5, rb.velocity.y);

                //! flip sprite menghadap kanan saat menekan D.
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                //
            }

            //! Jika menekan key spasi maka rigidbody melompat keatas.
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 10f);
                    Jump.Play();
                    isGrounded = false;
                }
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //! Mendeteksi posisi karakter jika telah menyentuh tanah setelah melompat (agar melompat hanya 1x tiap klik key Space)
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

       /*     if (collision.gameObject.CompareTag("Enemies"))
            {
                Destroy(collision.gameObject);
            }*/

        //! Skor +10 setiap menyentuh objek Cherry
        if (collision.gameObject.CompareTag("Collectable"))
        {
            //! Hilangkan objek Cherry yang telah disentuh
            Destroy(collision.gameObject);
            //! Tambahkan skor +10 setiap 1x objek Cherry didapat
            Score += 10;
            ScoreTxt.text = "Score: " + Score.ToString();
            Cherry.Play();
        }

        //! Game Over setiap menabrak musuh sebagai objek rintangan (Elang / Tikus / Duri)
        if (collision.gameObject.CompareTag("Enemies"))
        {
            //! Stop Background Music Playing Game
            bgSong.Stop();
            //! Play Background Music Game Over
            Dead.Play();
            //! Nyawa habis
            isAlive = false;
            //! Munculkan Panel Game Over
            panelGameOver.SetActive(true);
            //! Untuk mengetahui bahwa baru saja bermain di Level Easy, komparasi nilai tertingginya
            if (SceneManager.GetActiveScene().name == "LevelEasy")
            {
                global.setSkorEasy(getPlayerScore());
            }
            //! Untuk mengetahui bahwa baru saja bermain di Level Hard, komparasi nilai tertingginya
            else if(SceneManager.GetActiveScene().name == "LevelHard")
            {
                global.setSkorHard(getPlayerScore());
            }
        }

        //! Menang setiap mencapai Rumah di ujung kanan Map
        if (collision.gameObject.CompareTag("Rumah"))
        {
            //! Stop Background Music Playing Game
            bgSong.Stop();

            //! Untuk mengetahui bahwa baru saja bermain di Level Easy, komparasi nilai tertingginya
            if (SceneManager.GetActiveScene().name == "LevelEasy")
            {
                global.setSkorEasy(getPlayerScore());
            }
            //! Untuk mengetahui bahwa baru saja bermain di Level Hard, komparasi nilai tertingginya
            else if (SceneManager.GetActiveScene().name == "LevelHard")
            {
                global.setSkorHard(getPlayerScore());
            }

            SceneManager.LoadScene("EndGame");
        }
    }
}
