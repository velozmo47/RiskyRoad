using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class NodeConecter : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField, Range(2, 10)] int maxNodes = 3;
    [SerializeField] List<Node> nodes = new List<Node>();

    [Header ("Actions")]
    [SerializeField] UnityEvent onNodeInitialized;
    [SerializeField] UnityEvent onNodesConected;

    NodeConecterState state = NodeConecterState.StandBy;
    
    int currentNode;
    public bool isFull => nodes.Count >= maxNodes;

    void OnEnable()
    {
        if (state == NodeConecterState.StandBy && nodes.Count >= 2)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].InitializeNode();
            }

            SetupConnection();
        }
    }

    void FixedUpdate()
    {
        if (state == NodeConecterState.Connecting)
        {
            ConnectingNodes();
        }
    }

    public void SetupConnection()
    {
        state = NodeConecterState.Connecting;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, nodes[0].Connection);
        lineRenderer.SetPosition(1, nodes[0].Connection);
        currentNode = 1;
    }

    public void ConnectingNodes()
    {
        if (currentNode >= nodes.Count || nodes[currentNode].Initialized == false) { return; }

        Vector3 currentPos = lineRenderer.GetPosition(currentNode);
        Vector3 deltaMove = Vector3.MoveTowards(currentPos, nodes[currentNode].Connection, Time.deltaTime);
        lineRenderer.SetPosition(currentNode, deltaMove);

        if (deltaMove == nodes[currentNode].Connection)
        {
            currentNode++;

            if (currentNode >= maxNodes)
            {
                state = NodeConecterState.Connected;
                onNodesConected?.Invoke();
            }
            else
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(currentNode, nodes[currentNode - 1].Connection);
            }
        }
    }

    public void ConnectNode(Node node)
    {
        if (nodes.Count < maxNodes)
        {
            nodes.Add(node);

            if (nodes.Count == 2)
            {
                SetupConnection();
            }

            if (!isFull)
            {
                onNodeInitialized?.Invoke();
            }
        }
    }

    public enum NodeConecterState
    {
        StandBy,
        Connecting,
        Connected
    }
}
