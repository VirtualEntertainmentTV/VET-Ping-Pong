using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody MyBody;

    private Vector3 InitialImpulse;

    private Vector3 InitialPosition;

    [SerializeField]
    private float ImpulseForce = 10f;

    public Text Player1_ScoreText, Player2_ScoreText;
    private int p1_Score, p2_Score;

    void Awake()
    {
        InitialPosition = transform.position;

        MyBody = GetComponent<Rigidbody>();

    }



    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0, 2) > 0)
        {
            ImpulseForce *= -1f;
        }

        InitialImpulse = new Vector3(ImpulseForce, 0f, ImpulseForce);

        StartCoroutine(BallStartMoving());
    }

    IEnumerator BallStartMoving()
    {
        yield return new WaitForSeconds(2f);
        MyBody.AddForce(InitialImpulse, ForceMode.Impulse);
    }

    void SetScore()
    {
        Player1_ScoreText.text = "Player1; " + p1_Score;
        Player2_ScoreText.text = "Player2; " + p2_Score;
    }

    void ResetMovement()
    {
        MyBody.velocity = Vector3.zero;
        transform.position = InitialPosition;

        StartCoroutine(BallStartMoving());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player 1 Score")
        {
            p2_Score++;
            SetScore();

            ResetMovement();
        }

        if (other.tag == "Player 2 Score")
        {
            p1_Score++;
            SetScore();

            ResetMovement();
        }

    }

}
