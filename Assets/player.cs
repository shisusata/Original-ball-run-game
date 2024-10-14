using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class player : MonoBehaviour
{
    Rigidbody rb;
    public static int score;
    public Text stage;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(50, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-50, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
        }
        rb.AddForce(new Vector3(0, 0, 30));
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            score++;
           

            Debug.Log("aaa");


        }
        if (other.gameObject.CompareTag("red"))
        {
            Destroy(other.gameObject);
            score += 3;


            Debug.Log("aaa");


        }
        if (other.gameObject.CompareTag("special"))
        {
            Destroy(other.gameObject);
            score += 10;





        }
        if (other.gameObject.CompareTag("next"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("Stage2");
            stage.text = "Go to stage2 !";
            Invoke("Hakushi", 10);//Invoke( stage.text = "   ",10)
        }
        if (other.gameObject.CompareTag("next2"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("Stage3");
            stage.text = "Go to Last Stage !";
            Invoke("Hakushi", 10);//Invoke( stage.text = "   ",10)
        }
        if (other.gameObject.CompareTag("next3"))
        {
            if (score >= 60)
            {
                SceneManager.LoadScene("Clear");
            }
            else
            {
                SceneManager.LoadScene("Gameover");
            }

        }
        if (other.gameObject.CompareTag("-point"))
        {
            score -= 3;
        }
        if (other.gameObject.CompareTag("out"))
        {
            SceneManager.LoadScene("Gameover");

        }
        {

            if (other.gameObject.CompareTag("enemy"))
            {
                Destroy(other.gameObject);
                score++;


                Debug.Log("aaa");


            }
            if (other.gameObject.CompareTag("red"))
            {
                Destroy(other.gameObject);
                score += 3;


                Debug.Log("aaa");


            }
            if (other.gameObject.CompareTag("special"))
            {
                Destroy(other.gameObject);
                score += 10;





            }
            if (other.gameObject.CompareTag("next"))
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene("Stage2");
                stage.text = "Go to stage2 !";
                Invoke("Hakushi", 10);//Invoke( stage.text = "   ",10)
            }
            if (other.gameObject.CompareTag("next2"))
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene("Stage3");
                stage.text = "Go to Last Stage !";
                Invoke("Hakushi", 10);//Invoke( stage.text = "   ",10)
            }
            if (other.gameObject.CompareTag("next3"))
            {
                if (score >= 60)
                {
                    SceneManager.LoadScene("Clear");
                }
                else
                {
                    SceneManager.LoadScene("Gameover");
                }

            }
            if (other.gameObject.CompareTag("-point"))
            {
                score -= 3;
            }
            if (other.gameObject.CompareTag("out"))
            {
                SceneManager.LoadScene("Gameover");
            }

        }
       

    }
    private void Hakushi()
    {
        stage.text = "     ";
    }
}


