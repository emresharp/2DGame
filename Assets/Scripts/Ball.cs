using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D Ball_Rigidbody;
    LineRenderer Ball_LİneRenderer;
    SpringJoint2D Ball_SpringJoint;
    TrailRenderer Ball_TrailRenderer;

    public GameObject Hook_Object;
    Rigidbody2D Hook_Object_Rigidbody;

    public GameObject Not_Pushed_Button_Object;
    public GameObject Pushed_Button_Object;

    private float MaxDragDistance = 3f;
    private float Ball_ReleaseDelay;
    private bool isPressed;
    private float Current_Time;

    [SerializeField]
    private GameObject Ball_Explode_Effect;

    void Start()
    {
        Ball_Rigidbody = GetComponent<Rigidbody2D>();
        Ball_LİneRenderer = GetComponent<LineRenderer>();
        Ball_TrailRenderer = GetComponent<TrailRenderer>();
        Ball_SpringJoint = GetComponent<SpringJoint2D>();
        Hook_Object_Rigidbody = GetComponent<Rigidbody2D>();

        Ball_LİneRenderer.enabled = false;
        Ball_ReleaseDelay = 1 / (Ball_SpringJoint.frequency * 4);

        Hook_Object_Rigidbody = Ball_SpringJoint.connectedBody;

        Not_Pushed_Button_Object.SetActive(true);
        Pushed_Button_Object.SetActive(false);

        isPressed = false;
    }

    void Update()
    {
        if (isPressed)
        {
            DragBall();
        }
    }

    void DragBall()
    {
        SetLineRendererPosition();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, Hook_Object_Rigidbody.position);

        if (distance > MaxDragDistance)
        {
            Vector2 direction = (mousePosition - Hook_Object_Rigidbody.position).normalized;
            Ball_Rigidbody.position = Hook_Object_Rigidbody.position + direction * MaxDragDistance;
        }
        else
        {
            Ball_Rigidbody.position = mousePosition;
        }
    }

    void SetLineRendererPosition()
    {
        Vector3[] position = new Vector3[2];
        position[0] = Ball_Rigidbody.position;
        position[1] = Hook_Object_Rigidbody.position;
        Ball_LİneRenderer.SetPositions(position);
    }

    private void OnMouseDown()
    {
        isPressed = true;
        Ball_Rigidbody.isKinematic = true;
        Ball_LİneRenderer.enabled = true;
        Ball_TrailRenderer.enabled = false;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        Ball_Rigidbody.isKinematic = false;
        Ball_LİneRenderer.enabled = false;
        Ball_TrailRenderer.enabled = true;

        StartCoroutine(Releases());
    }

    private IEnumerator Releases()
    {
        yield return new WaitForSeconds(Ball_ReleaseDelay);
        Ball_SpringJoint.enabled = false;
        Ball_Rigidbody.constraints = RigidbodyConstraints2D.None;
    }

    public void Explode_Ball()
    {
        GameObject e = Instantiate(Ball_Explode_Effect, transform.position, Quaternion.identity);
        Destroy(e, 0.75f);
    }

    void Push_Button()
    {
        Not_Pushed_Button_Object.SetActive(false);
        Pushed_Button_Object.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Push_Button();  
    }
}
