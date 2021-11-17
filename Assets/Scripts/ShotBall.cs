using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBall : MonoBehaviour
{
    int counter = 0;
    [SerializeField] public string colorVariant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        transform.position += transform.up * 0.25f;
        if(counter >= 200) { Destroy(this.gameObject); }

        RaycastHit2D collided = Physics2D.Raycast(transform.position, transform.up, 0.1f, LayerMask.GetMask("Default"), -10f, 10f);
        if (collided && collided.transform.tag == "Wall")
        {

            Vector3 Rotation = transform.rotation.eulerAngles;
            Rotation.z *= -1;
            transform.rotation = Quaternion.Euler(Rotation);
        }
        else if (collided && (collided.transform.gameObject != this.gameObject) && (collided.transform.tag == "TopLimit"
            || collided.transform.tag == "BlueBall"
            || collided.transform.tag == "RedBall"
            || collided.transform.tag == "GreyBall"
            || collided.transform.tag == "YellowBall"
            || collided.transform.tag == "PurpleBall"))
        {
            GetComponent<ShotBall>().enabled = false;
            GetComponent<StaticBall>().enabled = true;
            
        }
    }


}
