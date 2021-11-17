using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] BallPreviewer ballBagPreview;
    [SerializeField] LineRenderer line;
    public GameObject ballToShoot;

    float X = 0;
    [Range(1, 10)] public int sensitivity = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MouseOrientation();
        LineDraw();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(!GlobalVar.Reloading)
        {
            ballToShoot = Instantiate(ballBagPreview.activeball, transform.position + transform.up * 1f, transform.rotation);
            ballToShoot.GetComponent<ShotBall>().enabled = true;
            ballBagPreview.ballFired();
        }
        
    }

    void MouseOrientation()
    {
        X -= Input.GetAxis("Mouse X") * (sensitivity);

        Vector3 Rotation = transform.rotation.eulerAngles;
        X = Mathf.Clamp(X, -60, 60);
        Rotation.z = X;
        if (Rotation.z < 0) { Rotation.z += 360; }

        transform.rotation = Quaternion.Euler(Rotation);
    }

    void LineDraw()
    {
        float lineDist = 8f;
        LayerMask layermask = 1 << 9;
        layermask = ~layermask;

        RaycastHit2D collided = Physics2D.Raycast(transform.position + transform.up * 0.5f, transform.up, lineDist, layermask, -10f, 0f);
        //Debug.DrawRay(transform.position + transform.up * 0.5f, transform.up * lineDist, Color.white, 0.1f);

        line.SetPosition(0, transform.position + (transform.up * 0.5f));
        if (collided)
        {
            //print(collided.transform.gameObject.name);
            
            if (collided.transform.tag == "Wall")
            {
                float remainDist = lineDist - Vector3.Distance(collided.point, transform.position + transform.up * 0.5f);

                RaycastHit2D collided2 = Physics2D.Raycast(collided.point, Vector3.Reflect(transform.up, Vector3.left), lineDist, layermask, -10f, 0f) ;
                //Debug.DrawRay(collided.point, Vector3.Reflect(transform.up, Vector3.left) * lineDist, Color.white, 0.1f);
                line.SetPosition(1, transform.position + transform.up * Vector3.Distance(collided.point, transform.position + transform.up * 0.5f));
                line.SetPosition(2, collided.point + (Vector2.Reflect(transform.up, Vector3.left) * remainDist));
            }
            else
            {
                Vector2 Pos = new Vector2();
                Pos.x = transform.position.x;
                Pos.y = transform.position.y;
                line.SetPosition(1, transform.position + transform.up * Vector3.Distance(collided.point, transform.position + transform.up * 0.5f));
                line.SetPosition(2, transform.position + transform.up * Vector3.Distance(collided.point, transform.position + transform.up * 0.5f));
            }
            
        }
        else
        {
            //print("no collision");
            line.SetPosition(1, transform.position + (transform.up * lineDist));
            line.SetPosition(2, transform.position + (transform.up * lineDist));

        }
    }
}
