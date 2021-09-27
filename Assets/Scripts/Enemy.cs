using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    [SerializeField] List<Blocks> way;

    private Dictionary<Vector3, Blocks> saveWay = new Dictionary<Vector3, Blocks>();
    //private Vector3 moveUp = new Vector3(0, 2, 0);

    private Vector3[] Directions = {Vector3.forward, Vector3.right, Vector3.back, Vector3.left};

    public List<Blocks> endPath = new List<Blocks>();

    public Blocks startCenter;
    public Blocks endCenter;

    private Vector3 Pos;

    public Blocks previous;

    private GameObject start;

    private GameObject end;

    private Vector3 tempCenter;

    public Vector3 Center;

    Queue<Vector3> queue = new Queue<Vector3>();
    public List<Blocks> PreviousCenter = new List<Blocks>();

    void Start()
    {
        AddBlocks();
        TopColor(Color.blue, Color.red);
        BFS();

        //gameObject.transform.position = Vector3.up;

        //StartCoroutine(Path());
    }

    /*IEnumerator Path()
    {
        foreach (Blocks blocks in way)
        {
            transform.position = blocks.transform.position + moveUp;
            yield return new WaitForSeconds(1f);

        }

    }*/

    void AddBlocks()
    {
        var targetBlock = FindObjectsOfType<Blocks>();

        foreach (Blocks blocks in targetBlock)
        {
            bool overlap = saveWay.ContainsKey(blocks.GetPosition());

            if (overlap)
            {
                Debug.LogWarning("Overlap");
            }

            else
            {
                saveWay.Add(blocks.GetPosition(), blocks);
            }
        }
    }

    void TopColor(Color startColor, Color endColor)
    {
        start = GameObject.FindWithTag("start");
        end = GameObject.FindWithTag("end");

        var meshrenderer = start.GetComponent<MeshRenderer>();
        meshrenderer.material.color = startColor;

        var endmesh = end.GetComponent<MeshRenderer>();
        endmesh.material.color = endColor;
    }

    void BFS()
    {
        Pos = startCenter.GetPosition();
        Center = Pos;

        while (Center != endCenter.GetPosition())
        {
            CenterDirection();
        }

        print(Center);

        EndPath();
    }

    private void CenterDirection()
    {
        foreach (Vector3 direction in Directions)
        {
            tempCenter = Center;

            tempCenter += direction;

            if ((saveWay.ContainsKey(tempCenter)) && !(saveWay[tempCenter].Searched))
            {
                if (!(queue.Contains(tempCenter)))
                {
                    queue.Enqueue(tempCenter);
                }

                saveWay[tempCenter].SearchBlocks = saveWay[Center];
            }
        }

        try
        {
            saveWay[Center].Searched = true;

            Center = queue.Dequeue();
        }

        catch
        {
        }
    }

    void EndPath()
    {
        endPath.Add(endCenter);
        previous = saveWay[Center].SearchBlocks;

        while (previous != startCenter)
        {
            endPath.Add(previous);

            previous.top(Color.green);

            previous = previous.SearchBlocks;
        }
    }
}