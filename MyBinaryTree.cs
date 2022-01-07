/*
/*
 * Coursework 2 - Binary tree traversals
 * By: Christopher Diaz Montoya
 * ID: 24707686
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    // Class MyNode to hold one integer item
    // Left child leftChild 
    // Right child rightChild

    // Class identifier, declaring a public class, class has no behaviours only states
    // Methods define the class behaviours
    class MyNode
    {
        // Each node has three fields (Like variables but for classes)
        // Class fields
        public int item;
        public MyNode leftChild;
        public MyNode rightChild;

        // Default Constructor
        public MyNode()
        {
            item = 0;
            leftChild = null;
            rightChild = null;
        }
        // Constructor with integer value parameter which will be assinged to the field item.
        public MyNode(int value)
        {
            item = value;
            leftChild = null;
            rightChild = null;
        }
        // Type void, prints compact tree, accepts two parameters of type string and bool.
        // Done in here as need to access fields left and right child, easier done in MyNode class, did not attempt in MyBinaryTree class.
        public void printTree(string indentSpace, bool rightMostNode)
        {
            // Nothing really printed first time as indentSpace = ""
            Console.Write(indentSpace);
            // As indent changes each recursive call, first is "", so this is root.
            if (indentSpace == "")
            {
                // Prints root in blue
                Console.ForegroundColor = ConsoleColor.Blue;
                // Says root as root node printed here. \n used to seperate from above line in output.
                Console.Write("\n|-Root = ");
                // Creates space horizontally for node items to print further right each time.
                // Meaning the root is left most and leaves are right most numbers printed.
                indentSpace += "          ";
            }
            // If true, no more nodes in the line, execute below.
            else if (rightMostNode)
            {
                // Prints right most nodes in red
                Console.ForegroundColor = ConsoleColor.Red;
                // Prints for last node, right most node. .Write used so int in item printed next to it.
                Console.Write("|-R = ");
                // Creates space horizontally for node items to print further right each time.
                // Meaning the root is left most and leaves are right most number printed.
                indentSpace += "       ";
            }
            else // If not right most node.
            {
                // Prints left nodes in dark yellow as yellow barely visable.
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                // Prints L becuse item on the left side will be printed.
                Console.Write("|-L = ");
                // Updates indent space.
                indentSpace += "|      ";
            }
            // Changed to white so items printed in white = bright.
            Console.ForegroundColor = ConsoleColor.White;

            // Prints item next to whichever of the above conditions was met.
            // WriteLine used so no 2 items can be printed on the same line.
            Console.WriteLine(item);

            // Brings back orginal colour so rest of assingment is not in colours.
            Console.ForegroundColor = ConsoleColor.Gray;

            // Create list which stores type class MyNode, 
            List<MyNode> leaves = new List <MyNode> ();

            // If there is a left child add to list
            if (this.leftChild != null)
                leaves.Add(this.leftChild);
            // If there is a right child add to list
            if (this.rightChild != null)
                leaves.Add(this.rightChild);

            // Loops up to amount in list
            for (int i = 0; i < leaves.Count; i++)
            {
                /* 
                 * Leaf in index is next to be assessed, .printTree is a recursive call so is called until
                 * tree is printed, indentSpace is passed again so it is updated each time.
                 * The final part is to assess if true or not, this will allow the correct conditional statements
                 * to be met within the loop, with even being right (true) and odd being left (false).
                 */
                leaves[i].printTree(indentSpace, i == leaves.Count - 1);
            }
        }
    }
    // Class identifier, declaring a public class
    class MyBinaryTree
    {
        // Each tree has one field (Like variables but for classes)
        // The root is of type node which is the class before
        private MyNode root;

        // Default Constructor
        public MyBinaryTree()
        {
            // Root needs to be assinged a value
            root = null;
        }
        // Tree behaviour 1, returns type node class MyNode 
        public MyNode ReturnRoot()
        {
            // "return" Returns the root node to the main
            return root;
        }
        // Void returns nothing, accepts no parameters
        public void print()
        {
            // Method calls method/ behaviour within the root object. Passes two parameters.
            root.printTree("", true);
        }
        // Object behaviour, method defines behaviours within a class.
        // Does not return a type but populates the tree, accepts 1 number (int) as parameter.
        public void InsertNode(int id)
        {
            // Creates type class a new node with number passed in the method as the nodes item (item field)
            MyNode newNode = new MyNode(id);

            // If the tree has no root.
            if (root == null)
            {
                // First node created becomes the root.
                root = newNode;
                // First test to ensure root node is correct. Printe the item in the root. id used as root is 
                // and condition won't be met again.
                Console.WriteLine("\nRoot: " + id); 
            }
            else
            {
                /*
                 * Assign the new node to the appropriate parent by comparing the item.
                 * For example, if the given item is less then root's item then it goes to leftChild 
                 * else go to the rightChild. Continue until you find a situation where
                 */
                
                MyNode current = root; // To start loop with root.
                while (true)
                {
                    if (id < current.item)  // If id is less than the current item.
                    {
                        if (current.leftChild == null)  // If currents nodes left child is null.
                        {
                            current.leftChild = newNode; // Sets the left child as the new node.
                            break;
                        }
                        else // If not null.                   
                            current = current.leftChild; // Go to the left child of the current node.
                    }
                    else // Else the id is greater than or equal to the current item.
                    {
                        if (current.rightChild == null) // If current nodes right child is null.
                        {
                            current.rightChild = newNode; // Set the right child as the new node.
                            break;
                        }
                        else // If not null.
                        {
                            current = current.rightChild; // Go to the right child of the current node.
                        }
                    }
                }
            }
        }
        //NOTE: USE RECURSION FOR ALL THE BELOW TRAVERSAL ALGORITHM.
        // Of type void does not return anything to main, accepts type class MyNode as a parameter. Root is passed as a parameter.
        public void Preorder(MyNode tmpNode)
        {
            // Conditional statements.
            // If node returned is non existant (Node is a leaf and has no children).
            if (tmpNode == null)
                return; // Returns to parent node.
            // else execute code in parenthsis in else statement.
            else
            {
                // Prints node item, tmpNode = node object, .item = what the particular node field stores.
                // Each node stores something different hence dif nodes =  dif objects.
                // .Write used instead of .Writeline and space added to print in a line.
                Console.Write(tmpNode.item + "  ");
                // Recursive call, Preorder() calls the method again with the left child (field) of the node passed as a parameter.
                Preorder(tmpNode.leftChild);
                // If the node does not have a left child, recusive call with the right child.
                Preorder(tmpNode.rightChild);
            }
        }
        // Of type void does not return anything to main, accepts type class MyNode as a parameter. Root is passed as a parameter.
        public void Inorder(MyNode tmpNode)
        {
            // Conditional statements.
            // if node returned is non existant (Node is a leaf and has no children).
            if (tmpNode == null)
                return;
            else
            {
                // Recursive call, Inorder() calls the method again with the left child (field) of the node passed as a parameter.
                Inorder(tmpNode.leftChild);
                // If no more left children, print leaf node, or node arrived to.
                Console.Write(tmpNode.item + "  ");
                // If the node does not have a left child, re run the method with recusive call with the right child.
                Inorder(tmpNode.rightChild);
            }
        }
        // Of type void does not return anything to main, accepts type class MyNode as a parameter.
        public void Postorder(MyNode tmpNode)
        {
            // Conditional statements.
            // if node returned is non existant (Node is a leaf and has no children).
            if (tmpNode == null)
                return;
            else
            {
                // Recursive call, Postorder() calls the method again with the left child (field) of the node passed as a parameter.
                Postorder(tmpNode.leftChild);
                // If the node does not have a left child, re run the method with recusive call with the right child.
                Postorder(tmpNode.rightChild);
                // If the bottom of the tree found, leaf node, print item in node.
                Console.Write(tmpNode.item + "  ");
            }
        }
        // Of type void does not return anything to main, accepts type class MyNode as a parameter, root passed as a parameter.
        public void findItem20PreOrder(MyNode tmpNode)
        {
            // Base case if node passed is empty
            if (tmpNode == null)
                return;

            // Empty stack created called nodeDataStack, holds data type class nodes.
            Stack <MyNode> nodeDataStack = new Stack <MyNode> ();
            // .Push() passes the root into the stack          
            nodeDataStack.Push(root);

            // Declare empty list to print path backwards, needs to be mutable, list of int type.
            List <int> backPath = new List <int> ();

            /*
             * Print item at the top.
             * Save it in the list.
             * Pop item at the top of the stack.
             * Add right child to the stack first so left child is worked on first as last in is first out
             * in a stack.
             * Add left child to the stack so it is at the top.
             */

            // While loop which ends when stack is empty.
            while (nodeDataStack.Count != 0)
            {
                // .peek() returns the top node within the stack, assinged to topNode object.
                MyNode topNode = nodeDataStack.Peek();
                // prints item (field) in the top node object.
                Console.Write(topNode.item + "  ");
                // Adds item to the list to print back path at the end, done with.Append() to add to list.
                backPath.Add(topNode.item);
                // .pop() removes node at the top of stack as it is now stored in the list.
                nodeDataStack.Pop();
               
                // If the top nodes data (item) == 20 execute code in if statement.
                if (topNode.item == 20)
                {
                    // As item 20 is found, print found.
                    Console.Write("->  Item 20 found!");
                    // break, breaks the loop as the item has been found.
                    break;
                }
                // Pushes the right and left children of current node popped in the stack.
                // If node has neither re run the loop and ignore statements. != means as long as it does NOT = null.
                if (topNode.rightChild != null)
                {
                    // .push() to add child to stack.
                    nodeDataStack.Push(topNode.rightChild);
                }
                if (topNode.leftChild != null)
                {
                    nodeDataStack.Push(topNode.leftChild);
                }
            }
            // Below prints out string explaining what happens below it.
            Console.WriteLine("\nPath back to root is: ");
            // Reverses the list with .Reverse() method.
            backPath.Reverse();
            // Prints all elements in the reversed list, loops until all int elements in list printed.
            foreach (int x in backPath)
            {
                // Prints number in list with space for the next.
                Console.Write(x + "  ");
            }
        }
        // Of type void does not return anything to main, accepts type class MyNode as a parameter, root passed as a parameter.
        public void findItem30BFS(MyNode tmpNode)
        {
            // Base case if node passed is empty
            if (tmpNode == null) return;

            // Empty queue created called queue, holds data type class nodes.
            Queue <MyNode> queue = new Queue <MyNode> ();
            // .Enqueue() passes the root into the queue          
            queue.Enqueue(root);

            // Declare empty list to print path backwards, needs to be mutable
            List <int> backPath = new List <int> ();

            /*
             * Print item at the top.
             * Save it in the list.
             * Pop item in the queue.
             * Add left child to the queue first so left child is worked on first as first in is first out for queues.
             * Add right child to the queue so it is next.
             * This allows the algorithm to print the tree breadth ways.
             */

            // While loop which ends when queue is empty.
            while (queue.Count != 0)
            {
                // .peek returns the first node in queue, assinged to topNode, local varible can be used twice.
                MyNode topNode = queue.Peek();
                // prints item in the first node.
                Console.Write(topNode.item + "  ");
                // Adds topNodes data to the list to print back path, done with.Append().
                backPath.Add(topNode.item);
                // .Dequeue() removes node at the front of the queue.
                queue.Dequeue();

                // If the top nodes data (item) == 30 execute code in if statement.
                if (topNode.item == 30)
                {
                    // As item 30 is found print found
                    Console.Write("->  Item 30 found!");
                    // break, breaks the loop as the item has been found
                    break;
                }
                // Pushes the right and left children of 
                // current node dequeued into the queue.
                if (topNode.leftChild != null)
                {
                    // .Enqueue to add whats in () to queue, the current nodes left child.
                    queue.Enqueue(topNode.leftChild);
                }
                if (topNode.rightChild != null)
                {
                    queue.Enqueue(topNode.rightChild);
                }
            }
            // Below prints out the list backwards with .reverse to showpath back to root.
            Console.WriteLine("\nPath back to root is: ");
            // Reverses the list with .Reverse() method.
            backPath.Reverse();
            // Prints all elements in the list.
            foreach (int x in backPath)
            {
                Console.Write(x + "  ");
            }
        }
        // Method/ behaviour of type void, prints does not return anything, accepts class as a parameter. 
        public void Inorder20and30 (MyNode tmpNode)
        {
            // To return to parent node.
            if (tmpNode == null)
            {

                return;
            }
            // Next condition is if nodes field "item" = 20 to print item 20 found, but continue traversal.
            else if (tmpNode.item == 20)
            {
                // Recursive call, Inorder() calls the method again, as item 20 would be found but needs to be skipped
                // so traversal can be printed in the correct order. Otherwise remove line 314 to find item 20 faster skipping 
                // having to print item 16 and 17
                Inorder20and30(tmpNode.leftChild);
                // Once item 20 found and the nodes are printed in the correct traversal, print found.
                Console.WriteLine(tmpNode.item + "  " + "->  Item 20 found! Traversal will continue below.");
                // To continue recursive traversal call method/ behaviour again.
                Inorder20and30(tmpNode.rightChild);
            }
            else if (tmpNode.item == 30)
            {
                // Recursive call, Inorder() calls the method again to ensure traversal is printed in correct order.
                // Otherwise line below can be remove but traversal would print incorrectly skipping item 28.
                Inorder20and30(tmpNode.leftChild);
                Console.Write(tmpNode.item + "  " + "->  Item 30 found! End of recursive call.");
                // Note no recusive call after as last item is found so no need to traverse tree further so exits method/ behaviour.
            }
            else
            {
                // Recursive call, Inorder() calls the method again.
                Inorder20and30(tmpNode.leftChild);
                // Prints item found with space to printe nicely.
                Console.Write(tmpNode.item + "  ");
                // To continue recursive traversal.
                Inorder20and30(tmpNode.rightChild);
            }
        }
        // Mehtod behaviour type int array, as returns an int array. Asks user for input no need for parameter.
        public int [] userChoice()
        {
            // Asks user which tree they would like to use.
            Console.WriteLine("If you would like the assingment tree, enter \"tree\". \n" +
                "If you would like to enter a custom tree, press any key.");
            // Assigns user input to variable.
            string choice = Console.ReadLine();
            // If user input = these, execute code.
            if ((choice == "tree") || (choice == "TREE") || (choice == "Tree"))
            {
                // To inform user which tree wil be used.
                Console.WriteLine("The assingment tree will be used.\nThe tree works by having smaller numbers to the left and larger numbers to the right.");
                // Coursework tree stored in an array ready to be returned.
                int[] taskTree = new int[12] { 25, 15, 26, 13, 22, 30, 20, 23, 28, 33, 16, 17 };
                // Returns the assingment tree to be used
                return taskTree;
            }
            // If user wants a custom tree.
            else
            {
                // Print to inform user which tree they choose.
                
                try
                {
                    Console.WriteLine("You have choosen to create a custom tree.\nThe tree is populated with smaller numbers to the left and larger number to the " +
                    "right.");
                    int nodes;
                    int[] customTree;
                    // Promts user for input.
                    Console.WriteLine("How many nodes would you like to enter?");
                    // User input, read, converted to int and stored in a variable in one line.
                    nodes = Convert.ToInt32(Console.ReadLine()); // Size of tree.

                    // Counter for loop.
                    int x = 0;

                    // Creates array the size of users desired tree which stores integers. [Nodes] creates size of dynamic array.
                    customTree = new int[nodes];
                    // Loop counts up to size of users desired tree.
                    while (x < nodes)
                    {
                        // Prompts user for numerical data they want to input.
                        Console.WriteLine("Enter whole number " + (x + 1) + " into the tree: ");
                        int num = Convert.ToInt32(Console.ReadLine()); // Num=1 item (data) for a node.
                                                                       // Data added to array, x = add to array index x the num.
                        customTree[x] += num;
                        // x has 1 added each loop so starts at 0 and goes up.
                        x++;
                    }
                    return customTree;
                }
                catch
                {
                    Console.WriteLine("You may only enter whole numbers. Please try again.\n");
                    return userChoice();
                }
                // Returns the custom tree to be used
            }
        }
    }
    // Class identifier, program, main.
    class Program
    {
        // Main method, returns nothing = type void. Different to other methods as computer looks for this first to run program.
        static void Main(string[] args)
        {
            // Creates theTree object (Identity) from type class MyBinaryTree (Classes can create multiple objects).
            // Similar to how you can use multiple integer variables.
            MyBinaryTree theTree = new MyBinaryTree();
            
            /* 
             * Calls method in class, need objects name full stop and behaviour/ method being called
             * which allows user to use the assignment tree or make a custom tree.
             * Method/ behaviour userChoice returns an integer type array stored in treeBase, these are the numbers for the tree.
             */
            int [] treeBase = theTree.userChoice(); 

            // For loop to populate the tree with numbers in treeBase. i = loop number, incremented each loop.
            // Loop ends when i reaches the length of the array storing all the numbers.
            for (int i = 0; i < treeBase.Length; i++)
            {
                // Calls method/ behaviour in theTree object which allows to insert node one at a time, uses whatever is in the indexed array at the loop
                // number so it goes over all elements in the array, one by one.
                theTree.InsertNode(treeBase[i]); 
            }
            /* 
             * Used to ensure the root is stored as a variable of type MyNode class so that traversals start from the root,
             * MyNode declares type MyNode class, root is variable name, = is to assign what is returned to root variable, theTree is to acces the object
             * and .ReturnRoot() is to access the behaviour/ method within which returns the root.
             */
            MyNode root = theTree.ReturnRoot();

            Console.Write("\nTree printed:"); // To specifiy what is printed, \n to keep it neat.
            theTree.print(); // Calls method/ behaviour to print tree.

            // In-order traversal of this tree and print the items.
            // \n is used to seperate the three tasks so it is easy to read for the user.
            Console.WriteLine("\nInorder recursive traversal:"); // To state what is about to printed next.
            theTree.Inorder(root); // Calls the behaviour/ method within the "theTree" class, passes root as a paramater to start at the top of the tree.

            // Pre-order traversal of this tree and print the items.
            Console.WriteLine("\nPreorder recursive traversal:"); // To state what is about to printed next. \n used for new line.
            theTree.Preorder(root); // Calls the behaviour/ method within the "theTree" class, passes root as a paramater to start at the top of the tree.

            // Post-order traversal of this tree and print the items.
            Console.WriteLine("\nPostorder recursive traversal:");
            theTree.Postorder(root); // Calls the behaviour/ method within the "theTree" class, passes root as a paramater to start at the top of the tree.

            // Find item 20 with a stack in a preorder traversal.
            // double \n used from now on to leave an empty line between tasks as first three where part of task one. 
            Console.WriteLine("\n\nFind item 20 by printing each visted node using a preorder traversal with a stack:");
            theTree.findItem20PreOrder(root); // Calls the behaviour/ method within the "theTree" class, passes root as a paramater to start at the top of the tree.

            // Find item 30 with a queue using a breadth first search.
            Console.WriteLine("\n\nFind item 30 by printing each visted node using a breadth first search with a queue:");
            theTree.findItem30BFS(root); // Calls the behaviour/ method within the "theTree" class, passes root as a paramater to start at the top of the tree.

            // Find item 20 and 30
            Console.WriteLine("\n\nFind item 20 and 30 using inorder algorithm with recursion:");
            theTree.Inorder20and30(root); // Calls the behaviour/ method within the "theTree" class, passes root as a paramater to start at the top of the tree.

            // Prints out End of assignment and student details, \n to display neatly on new lines one after another.
            Console.WriteLine("\n\nEnd of assingment. \nBy: Christopher Diaz Montoya \nID: 24707686");
        }
    }
}
