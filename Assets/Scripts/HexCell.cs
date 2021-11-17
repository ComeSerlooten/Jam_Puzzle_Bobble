using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public List<GameObject> neighborCellsContent;
    public List<GameObject> neighborCells;

    public GameObject content;

    public int blueNeighbours = 0;
    public int redNeighbours = 0;
    public int yellowNeighbours = 0;
    public int greyNeighbours = 0;
    public int purpleNeighbours = 0;

    public int sameColorNeighbour = 0;

    public bool isFilled = false;

    // Start is called before the first frame update
    void Start()
    {

        LayerMask layermask = ~0;
        if (true)
        {
            // Top Right
            Vector3 positionOut = transform.position + Vector3.Normalize(transform.right + 1.5f * transform.up) / 2;
            Vector3 positionEnd = transform.right + 1.5f * transform.up;
            RaycastHit2D collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "HexCell"))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCells.Add(collided.transform.gameObject);
                }

            }

            // Top Left
            positionOut = transform.position + Vector3.Normalize(-transform.right + 1.5f * transform.up) / 2;
            positionEnd = -transform.right + 1.5f * transform.up;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "HexCell"))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCells.Add(collided.transform.gameObject);
                }

            }

            // Middle Left
            positionOut = transform.position + Vector3.Normalize(-transform.right) / 2;
            positionEnd = -transform.right;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "HexCell"))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCells.Add(collided.transform.gameObject);
                }

            }

            // Middle Right
            positionOut = transform.position + Vector3.Normalize(transform.right) / 2;
            positionEnd = transform.right;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "HexCell"))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCells.Add(collided.transform.gameObject);
                }

            }

            // Bottom Left
            positionOut = transform.position + Vector3.Normalize(-transform.right + -1.5f * transform.up) / 2;
            positionEnd = -transform.right + -1.5f * transform.up;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "HexCell"))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCells.Add(collided.transform.gameObject);
                }

            }

            // Bottom Right
            positionOut = transform.position + Vector3.Normalize(transform.right + -1.5f * transform.up) / 2;
            positionEnd = transform.right + -1.5f * transform.up;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "HexCell"))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCells.Add(collided.transform.gameObject);
                }

            }
        }

    }

    public void getNeighboursFirst()
    {
        LayerMask layermask = ~0;
        neighborCellsContent = new List<GameObject>();

        if (false) //Debug Hex Rays
        {
            Debug.DrawRay(transform.position, Vector3.Normalize(transform.right) / 2, Color.red, 0.1f);
            Debug.DrawRay(transform.position, Vector3.Normalize(-transform.right) / 2, Color.red, 0.1f);
            Debug.DrawRay(transform.position, Vector3.Normalize(transform.right + 1.5f * transform.up) / 2, Color.red, 0.1f);
            Debug.DrawRay(transform.position, Vector3.Normalize(-transform.right + 1.5f * transform.up) / 2, Color.red, 0.1f);
            Debug.DrawRay(transform.position, Vector3.Normalize(transform.right - 1.5f * transform.up) / 2, Color.red, 0.1f);
            Debug.DrawRay(transform.position, Vector3.Normalize(-transform.right - 1.5f * transform.up) / 2, Color.red, 0.1f);
        }

        // Check each position
        if (true)
        {
            // Top Right
            Vector3 positionOut = transform.position + Vector3.Normalize(transform.right + 1.5f * transform.up) / 2;
            Vector3 positionEnd = transform.right + 1.5f * transform.up;
            RaycastHit2D collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "TopLimit" || (collided.transform.tag == "HexCell" && collided.transform.GetComponent<HexCell>().isFilled)))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCellsContent.Add(collided.transform.gameObject.GetComponent<HexCell>().content);
                }
                else
                {
                    neighborCellsContent.Add(collided.transform.gameObject);
                }

            }

            // Top Left
            positionOut = transform.position + Vector3.Normalize(-transform.right + 1.5f * transform.up) / 2;
            positionEnd = -transform.right + 1.5f * transform.up;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "TopLimit" || (collided.transform.tag == "HexCell" && collided.transform.GetComponent<HexCell>().isFilled)))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCellsContent.Add(collided.transform.gameObject.GetComponent<HexCell>().content);
                }
                else
                {
                    neighborCellsContent.Add(collided.transform.gameObject);
                }

            }

            // Middle Left
            positionOut = transform.position + Vector3.Normalize(-transform.right) / 2;
            positionEnd = -transform.right;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "TopLimit" || (collided.transform.tag == "HexCell" && collided.transform.GetComponent<HexCell>().isFilled)))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCellsContent.Add(collided.transform.gameObject.GetComponent<HexCell>().content);
                }

            }

            // Middle Right
            positionOut = transform.position + Vector3.Normalize(transform.right) / 2;
            positionEnd = transform.right;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "TopLimit" || (collided.transform.tag == "HexCell" && collided.transform.GetComponent<HexCell>().isFilled)))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCellsContent.Add(collided.transform.gameObject.GetComponent<HexCell>().content);
                }

            }

            // Bottom Left
            positionOut = transform.position + Vector3.Normalize(-transform.right + -1.5f * transform.up) / 2;
            positionEnd = -transform.right + -1.5f * transform.up;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "TopLimit" || (collided.transform.tag == "HexCell" && collided.transform.GetComponent<HexCell>().isFilled)))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCellsContent.Add(collided.transform.gameObject.GetComponent<HexCell>().content);
                }

            }

            // Bottom Right
            positionOut = transform.position + Vector3.Normalize(transform.right + -1.5f * transform.up) / 2;
            positionEnd = transform.right + -1.5f * transform.up;
            collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
            if (collided && (collided.transform.tag == "TopLimit" || (collided.transform.tag == "HexCell" && collided.transform.GetComponent<HexCell>().isFilled)))
            {
                Debug.DrawRay(transform.position, Vector3.Normalize(positionEnd) / 2, Color.red, 0.1f);

                if (collided.transform.tag == "HexCell")
                {
                    neighborCellsContent.Add(collided.transform.gameObject.GetComponent<HexCell>().content);
                }

            }
        }
        neighbourCount();

    }

    public void getNeighbours()
    {
        neighborCellsContent = new List<GameObject>();
        foreach(GameObject cell in neighborCells)
        {
            if (cell.GetComponent<HexCell>().isFilled)
            {
                neighborCellsContent.Add(cell.GetComponent<HexCell>().content);
            }
        }

        /*
        LayerMask layermask = ~0;

        // Top Right
        Vector3 positionOut = transform.position + Vector3.Normalize(transform.right + 1.5f * transform.up) / 2;
        Vector3 positionEnd = transform.right + 1.5f * transform.up;
        RaycastHit2D collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
        if (collided && (collided.transform.tag == "TopLimit"))
        {
             neighborCellsContent.Add(collided.transform.gameObject);
        }

        // Top Left
        positionOut = transform.position + Vector3.Normalize(-transform.right + 1.5f * transform.up) / 2;
        positionEnd = -transform.right + 1.5f * transform.up;
        collided = Physics2D.Raycast(positionOut, positionEnd, 0.1f, layermask, transform.position.z - 2f, transform.position.z + 2f);
        if (collided && (collided.transform.tag == "TopLimit"))
        {
            neighborCellsContent.Add(collided.transform.gameObject);
        }*/


        neighbourCount();
        sameNeighbourCount();
    }

    public void neighbourCount()
    {

        blueNeighbours = 0;
        redNeighbours = 0;
        yellowNeighbours = 0;
        greyNeighbours = 0;
        purpleNeighbours = 0;

        foreach (GameObject neighbor in neighborCellsContent)
        {
            if (neighbor.tag == "BlueBall")
            {
                blueNeighbours += 1;
            }
            else if (neighbor.tag == "RedBall")
            {
                redNeighbours += 1;
            }
            else if (neighbor.tag == "YellowBall")
            {
                yellowNeighbours += 1;
            }
            else if (neighbor.tag == "GreyBall")
            {
                greyNeighbours += 1;
            }
            else if (neighbor.tag == "PurpleBall")
            {
                purpleNeighbours += 1;
            }
        }


    }


    public void sameNeighbourCount()
    {
        sameColorNeighbour = 0;
        if(isFilled)
        {
            foreach (GameObject neighbor in neighborCellsContent)
            {
                if (neighbor.tag == content.tag)
                {
                    sameColorNeighbour += 1;
                }
            }
        }
    }


    public void UpdateAtFill()
    {
        getNeighbours();

        foreach (GameObject cell in neighborCells)
        {
            cell.GetComponent<HexCell>().getNeighbours();
        }

    }

    public void deathCommand()
    {
        string contentTag = content.gameObject.tag;
        Destroy(content);
        content = null;
        isFilled = false;

        foreach (GameObject neighbor in neighborCellsContent)
        {
            if (neighbor.tag == contentTag)
            {
                neighbor.GetComponent<StaticBall>().hostCell.GetComponent<HexCell>().neighborCellsContent.Remove(content);
                neighbor.GetComponent<StaticBall>().hostCell.GetComponent<HexCell>().deathCommand();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        //getNeighbours();
    }
}
