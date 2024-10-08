namespace Lab3.Util;

public class Graph
{
    private readonly Dictionary<int, List<int>> _edges = new();
    
    public void AddEdge(int u, int v, bool reverse)
    {
        if (!_edges.ContainsKey(u))
            _edges.Add(u, new List<int>());
        if (!_edges[u].Contains(v))
            _edges[u].Add(v);

        if (reverse)
        {
            if (!_edges.ContainsKey(v))
                _edges.Add(v, new List<int>());
            if (!_edges[v].Contains(u))
                _edges[v].Add(u);
            
        }
    }
    
    public Dictionary<int, int> BreadthFirstSearch(int start)
    {
        var visited = new List<int>();
        var distance = new Dictionary<int, int>();
        var queue = new Queue<int>();
        
        distance[start] = 0;
        queue.Enqueue(start);
        
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            
            visited.Add(node);
            
            foreach (int neighbor in _edges[node].Where(neighbor => !visited.Contains(neighbor)))
            {
                queue.Enqueue(neighbor);
                distance[neighbor] = distance[node] + 1;
            }
        }
        return distance;
    }
}