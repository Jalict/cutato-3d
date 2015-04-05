using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
	public Transform SecondHand;

    public AudioClip tickSound;
    public AudioClip alarmSound;

    public float maxForce = 50;
    private Rigidbody rb;
    private bool isVibrating = false;
    private bool isTicking = false;
    private IEnumerator vibrateObject;

    private bool isMoving;

    void Awake()
    {
        rb = transform.root.GetComponent<Rigidbody>();
        vibrateObject = VibrateObject();

        MainGameManager.instance.StartTimer();

        isTicking = true;
        StartCoroutine(TickTock());
    }

    void OnEnable()
    {
        MainGameManager.timeout += StopClock;
    }

    void OnDisable()
    {
        MainGameManager.timeout -= StopClock;
    }

    public void StopClock()
    {
        isMoving = false;
        StopCoroutine("TickTock");
        isTicking = false;
        StartVibrate();
        StartCoroutine("SwitchScene");
    }

    public void StartClock()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine("TickTock");
        }
    }

    public IEnumerator TickTock()
    {
        while (isTicking)
        {
            float secondAngle = (MainGameManager.instance.timeRemaining) * (360 / 60);
            SecondHand.localRotation = Quaternion.Euler(0, 0, secondAngle);

            AudioSource.PlayClipAtPoint(tickSound, transform.position);

            yield return new WaitForSeconds(1);
        }
    }

    public void StartVibrate()
    {
        if (!isVibrating)
        {
            isVibrating = true;
            StopCoroutine(TickTock());
            StartCoroutine(vibrateObject);

            AudioSource.PlayClipAtPoint(alarmSound, transform.position);
        }
    }

    public void StopVibrate()
    {
        isVibrating = false;
        StopCoroutine(vibrateObject);
    }

    private IEnumerator VibrateObject()
    {
        while (true)
        {
            Vector3 randVector = new Vector3(Random.Range(-1.0f, 1.0f) * maxForce, Random.Range(-1.0f, 1.0f) * maxForce, Random.Range(-1.0f, 1.0f) * maxForce);
            rb.AddForce(randVector);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(4);

        Application.LoadLevel(2);
    }
}
