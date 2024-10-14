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
    public float jumpHeight = 2.0f;    // ジャンプの高さ
    public float jumpSpeed = 2.0f;     // ジャンプの速さ
    public float gravity = -9.8f;      // 重力の強さ


    private bool isJumping = false;    // ジャンプ中かどうかの判定
    private float initialY;            // ジャンプ開始時のY座標
    private float jumpVelocity;        // ジャンプ中のY軸速度




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
            rb.AddForce(new Vector3(30, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-30, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)//! = not
        {
            isJumping = true;
            initialY = transform.position.y;
            jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);  // 初速度を計算
        }
        // ジャンプ中の挙動
        if (isJumping)
        {
            // Y軸の移動を計算（ジャンプ速度と重力の影響）
            jumpVelocity += gravity * Time.deltaTime;
            transform.position += new Vector3(0, jumpVelocity * Time.deltaTime, 0);


            // 地面に戻ったらジャンプ終了
            if (transform.position.y <= initialY)
            {
                transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
                isJumping = false;
            }
        }


        rb.AddForce(new Vector3(0, 0, 15));
        
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
        
       

    }
    private void Hakushi()
    {
        stage.text = "     ";
    }
}


