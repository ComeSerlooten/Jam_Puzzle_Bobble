using System.Collections.Generic;
using UnityEngine;

public class StaticBall : MonoBehaviour
{
    public GameObject hostCell;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        hostCell = FindClosestCell();

        pos = transform.position;
        pos.x = hostCell.transform.position.x;
        pos.y = hostCell.transform.position.y;
        transform.position = pos;

        hostCell.GetComponent<HexCell>().isFilled = true;
        hostCell.GetComponent<HexCell>().content = this.gameObject;


        hostCell.GetComponent<HexCell>().UpdateAtFill();
        checkForDelete();
    }

    public GameObject FindClosestCell()
    {
        GameObject[] cells;
        cells = GameObject.FindGameObjectsWithTag("HexCell");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject hex in cells)
        {
            if(!hex.GetComponent<HexCell>().isFilled)
            {
                Vector3 diff = hex.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = hex;
                    distance = curDistance;
                }
            }
        }
        return closest;
    }


    public void checkForDelete()
    {
        List<GameObject> hexs = hostCell.GetComponent<HexCell>().neighborCells;
        hexs.Add(hostCell);

        string selfTag = gameObject.tag;

        foreach (GameObject cell in hexs)
        {

            if (selfTag == "BlueBall")
            {
                if (cell.GetComponent<HexCell>().blueNeighbours >= 2)
                {
                    cell.GetComponent<HexCell>().deathCommand();
                }
            }

            else if (selfTag == "RedBall")
            {
                if (cell.GetComponent<HexCell>().redNeighbours >= 2)
                {
                    cell.GetComponent<HexCell>().deathCommand();
                }
            }

            else if (selfTag == "GreyBall")
            {
                if (cell.GetComponent<HexCell>().greyNeighbours >= 2)
                {
                    cell.GetComponent<HexCell>().deathCommand();
                }
            }

            else if (selfTag == "YellowBall")
            {
                if (cell.GetComponent<HexCell>().yellowNeighbours >= 2)
                {
                    cell.GetComponent<HexCell>().deathCommand();
                }
            }

            else if (selfTag == "PurpleBall")
            {
                if (cell.GetComponent<HexCell>().purpleNeighbours >= 2)
                {
                    cell.GetComponent<HexCell>().deathCommand();
                }
            }
        }
    }

    
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
