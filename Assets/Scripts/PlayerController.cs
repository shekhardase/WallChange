using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] GameObject timerTxtParent;
    [SerializeField] ParticleSystem playerBurstEffect;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip popSE;

    internal static bool left = false;
    internal static bool right = false;

    private bool startTimer = false;
    private float timer = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);

        if (left && transform.position.x >= -1.5f)
        {
            transform.Translate(-Vector3.right * Time.deltaTime * moveSpeed);
        }
        else if (right && transform.position.x <= 1.5f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }


        if (startTimer)
        {
            timer -= Time.deltaTime;
            timerTxtParent.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((int)timer).ToString();
        }
        if (timer <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            moveSpeed = 0;
            startTimer = false;
            playerBurstEffect.Play();
            playerBurstEffect = null;
            
            audioSource.clip = popSE;
            audioSource.loop = false;
            audioSource.Play();
            Invoke("GameOver", 2.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            moveSpeed = 0;
            playerBurstEffect.Play();
            playerBurstEffect = null;
            audioSource.clip = popSE;
            audioSource.loop = false;
            audioSource.Play();            
            Invoke("GameOver", 2.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            startTimer = true;
            timer = 5f;
            timerTxtParent.SetActive(true);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
