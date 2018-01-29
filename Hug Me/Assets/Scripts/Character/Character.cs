using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    bool game;
    public GameObject barLife;
    public GameObject menu;
    public Fade textFade;
    public GameObject villagerSpawner;

    RaycastHit2D rayHit;
    private float rayDistance;
    public float threshold;
  
    public float InverseVelocity;
    private float h = 0, v = 0, rh = 0, rv = 0;
    public bool right, up, left, down;
    public float walkAnimationDistance;
    public AnimationClip clip;
    public bool canMove;

    [Space]

    public LayerMask houseLayer;

    [Space]

    public Collider2D coll;

    public AudioClip step;


    public void playStep()
    {
        GetComponent<AudioSource>().PlayOneShot(step);
    }
    // Use this for initialization
    void Start()
    {
        rayDistance = 2;

        coll = GetComponent<Collider2D>();

        right = true;
        up = true;
        left = true;
        down = true;

        textFade.OutputInstruction();
    }
    // Update is called once per frame
    void Update()
    {
        CharacterMove();
    }
    public void CharacterMove()
    {
        if (!game)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                game = true;

                menu.SetActive(false);

                StartCoroutine(ProccedtoMove());
            }
        }
        if (canMove)
        {
            h += Input.GetAxis("Horizontal");
            v += Input.GetAxis("Vertical");
            rh = Mathf.Clamp(h, -1, 1);
            rv = Mathf.Clamp(v, -1, 1);
            h -= rh / 2f;
            v -= rv / 2f;
            h = Mathf.Clamp(h, -50, 50);
            v = Mathf.Clamp(v, -50, 50);

            // Rigth
            bool[] rightResults = new bool[3];

            for (int i = 1; i >= -1; i--)
            {
                Vector2 rayOrigin = new Vector2(transform.position.x + coll.bounds.extents.x - threshold, transform.position.y + (coll.bounds.extents.y * -i));

                // Draw Line
                Debug.DrawRay(rayOrigin, Vector3.right / rayDistance, Color.cyan);

                // If a gameobject has collider and the distance between the two is less than 1
                if (Physics2D.Raycast(rayOrigin, Vector3.right / rayDistance, 1 / rayDistance, houseLayer))
                {
                    rightResults[i + 1] = false;
                }
                else
                {
                    rightResults[i + 1] = true;
                }
            }
            right = true;
            for (int i = 0; i < 3; i++)
            {
                if (!rightResults[i])
                {
                    right = false;
                }
            }

            // up
            bool[] upResults = new bool[3];

            for (int i = 1; i >= -1; i--)
            {
                Vector2 rayOrigin = new Vector3(transform.position.x + (coll.bounds.extents.x * -i), transform.position.y + coll.bounds.extents.y - threshold);

                // Draw Line
                Debug.DrawRay(rayOrigin, Vector3.up / rayDistance, Color.cyan);

                // If a gameobject has collider and the distance between the two is less than 1
                if (Physics2D.Raycast(rayOrigin, Vector3.up / rayDistance, 1 / rayDistance, houseLayer))
                {
                    upResults[i + 1] = false;
                }
                else
                {
                    upResults[i + 1] = true;
                }
            }
            up = true;
            for (int i = 0; i < 3; i++)
            {
                if (!upResults[i])
                {
                    up = false;
                }
            }

            // Left
            bool[] leftResults = new bool[3];

            for (int i = 1; i >= -1; i--)
            {
                Vector2 rayOrigin = new Vector3(transform.position.x - coll.bounds.extents.x + threshold, transform.position.y + (coll.bounds.extents.y * -i));

                // Draw Line
                Debug.DrawRay(rayOrigin, Vector3.left / rayDistance, Color.cyan);

                // If a gameobject has collider and the distance between the two is less than 1
                if (Physics2D.Raycast(rayOrigin, Vector3.left / rayDistance, 1 / rayDistance, houseLayer))
                {

                    leftResults[i + 1] = false;
                }
                else
                {
                    leftResults[i + 1] = true;
                }
            }
            left = true;
            for (int i = 0; i < 3; i++)
            {
                if (!leftResults[i])
                {
                    left = false;
                }
            }

            // down
            bool[] downResults = new bool[3];

            for (int i = 1; i >= -1; i--)
            {
                Vector2 rayOrigin = new Vector3(transform.position.x + (coll.bounds.extents.x * -i), transform.position.y - coll.bounds.extents.y + threshold);

                // Draw Line
                Debug.DrawRay(rayOrigin, Vector3.down / rayDistance, Color.cyan);

                // If a gameobject has collider and the distance between the two is less than 1
                if (Physics2D.Raycast(rayOrigin, Vector3.down / rayDistance, 1 / rayDistance, houseLayer))
                {
                    downResults[i + 1] = false;
                }
                else
                {
                    downResults[i + 1] = true;
                }
            }
            down = true;
            for (int i = 0; i < 3; i++)
            {
                if (!downResults[i])
                {
                    down = false;
                }
            }

            if (!right)
            {
                if (h > 0)
                {
                    h = 0;
                }
            }
            if (!up)
            {
                if (v > 0)
                {
                    v = 0;
                }
            }
            if (!left)
            {
                if (h < 0)
                {
                    h = 0;
                }
            }
            if (!down)
            {
                if (v < 0)
                {
                    v = 0;
                }
            }

            Vector3 desplazamiento = new Vector3(h / InverseVelocity * Time.timeScale, v / InverseVelocity* Time.timeScale, 0);

            if (h > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (h < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            if (h <= -walkAnimationDistance || h >= walkAnimationDistance || v <= -walkAnimationDistance || v >= walkAnimationDistance)
            {
                GetComponent<Animator>().SetBool("Walk", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Walk", false);
            }

            transform.position += desplazamiento;
        }
    }

    // coroutines
    public IEnumerator ProccedtoMove()
    {
        yield return new WaitForSeconds(2);

        GetComponent<Animator>().SetBool("Intro", true);

        yield return new WaitForSeconds(clip.length);

        transform.GetChild(0).gameObject.SetActive(true);

        canMove = true;

        barLife.SetActive(true);

        GetComponent<LifeController>().canDownLife = true;

        villagerSpawner.SetActive(true);

        StopCoroutine("ProccedtoMove");
    }
}
