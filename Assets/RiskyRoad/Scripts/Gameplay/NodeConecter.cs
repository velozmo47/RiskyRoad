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

    void Awake()
    {
        lineRenderer.positionCount = 0;
    }

    void OnEnable()
    {
        if (state == NodeConecterState.StandBy && nodes.Count >= 2)
        {
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

    void SetupConnection()
    {
        if (nodes.Count == 2)
        {
            state = NodeConecterState.Connecting;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, nodes[0].Connection);
            lineRenderer.SetPosition(1, nodes[0].Connection);
            currentNode = 1;
        }
    }

    void ConnectingNodes()
    {
        if (currentNode >= nodes.Count) { return; }

        if (nodes[currentNode].Initialized == false)
        {
            nodes[currentNode].InitializeNode();
        }

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
        if (nodes.Count >= maxNodes) { return; }

        nodes.Add(node);
        if (!isFull)
        {
            SetupConnection();
            onNodeInitialized?.Invoke();
        }
    }

    public enum NodeConecterState
    {
        StandBy,
        Connecting,
        Connected
    }
}
