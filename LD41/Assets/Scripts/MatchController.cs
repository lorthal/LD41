using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public enum State
    {
        Playing,
        Pause,
        ReadyToStart,
        End
    }

    public static MatchController Instance;

    public GameObject end;

    public float MatchTimeInSeconds;
    public float TimeToStart;
    public float PauseTime;

    public GameObject Player1, Player2, Ball;

    public int Player1Score { get; private set; }
    public int Player2Score { get; private set; }

    public float TimeLeft { get; private set; }

    public State state { get; private set; }

    public float startTimer { get; private set; }
    private float pauseTimer;

    private Transform Player1StartPosition, Player2StartPosition, BallStartPosition;
    private Rigidbody ballRigidbody;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        state = State.Pause;
        TimeLeft = MatchTimeInSeconds;
        Player1StartPosition = Player1.transform.Clone();
        Player2StartPosition = Player2.transform.Clone();
        BallStartPosition = Ball.transform.Clone();
        ballRigidbody = Ball.GetComponent<Rigidbody>();
        RestartAfterGoal();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Playing)
        {
            if (TimeLeft <= 0)
            {
                EndGame();
            }
            TimeLeft -= Time.deltaTime;
        }

        if (state == State.ReadyToStart)
        {
            if (startTimer <= 0)
            {
                Play();
            }
            startTimer -= Time.deltaTime;
        }

        if (state == State.Pause)
        {
            if (pauseTimer <= 0)
            {
                RestartAfterGoal();
            }
            pauseTimer -= Time.deltaTime;
        }
        if(state == State.End)
        {
            end.SetActive(true);
        }
        else
        {
            end.SetActive(false);
        }
    }

    public void AddScore(string player)
    {
        if (player == "Player1")
        {
            Player1Score++;
        }
        else
        {
            Player2Score++;
        }
        Pause();
    }

    private void RestartAfterGoal()
    {
        Player1.GetComponent<MoveBehaviour>().Reset();
        Player2.GetComponent<MoveBehaviour>().Reset();
        Player1.GetComponent<BasicBehaviour>().Reset();
        Player2.GetComponent<BasicBehaviour>().Reset();

        Player1.transform.position = Player1StartPosition.position;
        Player1.transform.rotation = Player1StartPosition.rotation;

        Player2.transform.position = Player2StartPosition.position;
        Player2.transform.rotation = Player2StartPosition.rotation;

        Player1.GetComponent<BasicBehaviour>().weapon.ammo = 2;
        Player2.GetComponent<BasicBehaviour>().weapon.ammo = 2;

        Ball.SetActive(true);

        Ball.transform.position = BallStartPosition.position;
        Ball.transform.rotation = BallStartPosition.rotation;

        ballRigidbody.useGravity = false;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.angularDrag = 0;
        ballRigidbody.velocity = Vector3.zero;

        state = State.ReadyToStart;
        startTimer = TimeToStart;
    }

    private void Pause()
    {
        state = State.Pause;
        pauseTimer = PauseTime;
    }

    private void Play()
    {
        state = State.Playing;
        ballRigidbody.useGravity = true;
    }

    private void EndGame()
    {
        state = State.End;
    }
}

public static class TransformExt
{
    public static Transform Clone(this Transform trans)
    {
        GameObject go = GameObject.Instantiate(new GameObject(), trans);
        go.transform.parent = MatchController.Instance.gameObject.transform;
        go.name = "CopiedTransform";
        return go.transform;
    }
}
