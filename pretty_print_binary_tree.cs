// Print a binary tree by levels.
void Main()
{
	Node root = GetTestTree();
	Console.WriteLine(PrettifyBinaryTree(root));
}

// Basically it's a breadth first search, which
// is perfect for Queue data structure. We don't need
// a recursive call like we do in depth first thanks to
// the queue as well. Just loop until the queue in to empty.
//
// I could've printed right inside the method but I'm a fan
// of pure functions, so building a string first and then print it
// is a better approach for me. No sideeffects.
string PrettifyBinaryTree(Node root)
{
	StringBuilder sb = new StringBuilder();
	
	if (root == null) { return ""; }
	
	Queue<Node> nodesToVisit = new Queue<Node>();
	nodesToVisit.Enqueue(root);
	
	int countNodesCurrentLevel = 1; // root in q
	int countNodesNextLevel = 0;

	while (nodesToVisit.Count > 0)
	{
		Node currentNode = nodesToVisit.Dequeue();
		countNodesCurrentLevel--;

		if (currentNode != null)
		{
			sb.Append(currentNode).Append(" ");
			nodesToVisit.Enqueue(currentNode.Left);
			nodesToVisit.Enqueue(currentNode.Right);
			countNodesNextLevel += 2;
		}

		if (countNodesCurrentLevel == 0)
		{
			sb.AppendLine();
			countNodesCurrentLevel = countNodesNextLevel;
			countNodesNextLevel = 0;
		}
	}
	
	return sb.ToString();
}

// Sample tree builder. For testing.
Node GetTestTree()
{
	var root = new Node("A");
	root.Left = new Node("B");
	root.Right = new Node("C");
	root.Left.Left = new Node("D");
	root.Left.Right = new Node("E");
	root.Right.Left = new Node("F");
	root.Right.Left.Right = new Node("G");
	
	return root;
}

class Node
{
	public Node (String data)
	{
		Data = data;
	}
	public Node Left { get; set; }
	public Node Right { get; set; }
	public string Data { get; set;}
	
	public override string ToString()
	{
		return Data;
	}
}