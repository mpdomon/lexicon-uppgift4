﻿using System;


/*
1.Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess 
grundläggande funktion

Stacken är självunderhållande där efter stacken kört metoden eller anropen så kastas de bort. Value types kan lagras på stacken.

Heapen är lite av en öppen samling där man kan hämta fritt och inte behöver köra något i ordning som på stacken. 
För att underhålla heapen används garbage collections. Reference types används alltid på heapen men value types kan även användas
på heapen beroende på vart de deklareras. 

2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
Value types är från System.ValueType och är typen, alltså bool, int, char osv. Dock INTE string. 

Reference types ärver från System.Object och är mer dina byggblock, som class, interface, object, delegate och även string.

3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den 
andra returnerar 4, varför? 
För att när y = x så är fortfarande värdet av x 3, y tilldelas 4 efter så när return x körs så blir x fortfarande 3. 

I andra exemplaret så pekar x och y på samma objekt. Det är väl skillnaden på heap och stack, då andra exemplaret använder heap
*/

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, will handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            /*
            1. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
            När storleken når kapaciteten
            3. Med hur mycket ökar kapaciteten?
            Dubbelt. 4 > 8 > 16 osv
            4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
            Det skulle göra appen/listan för långsam
            5. Minskar kapaciteten när element tas bort ur listan?
            Nix
            6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista
            För enklare situationer där alla extra funktioner för listor kanske inte behövs osv. 

            */

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
 {
        List<string> theList = new List<string>();
            bool looping = true;

            do
            {
                Console.WriteLine("Add or remove names from the list using \"-\" or \"+\". " +
                    "\nExamples: " +
                    "\nto add Adam, write \"+Adam\" " +
                    "\nto remove Adam, write  \"-Adam\" " +
                    "\npress r to return");
                string input = Console.ReadLine();

                if (input.Equals("return", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                //Null proofing the menu.
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please write a valid command for the menu");
                    continue;
                }
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added {value}");
                        Console.WriteLine($"capacity check: {theList.Capacity}. Count check: {theList.Count}");
                        break;

                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Removed {value}");
                        Console.WriteLine($"capacity check: {theList.Capacity}. Count check: {theList.Count}");
                        break;

                    case 'r':
                        Console.WriteLine("Returning.. \n");
                        looping = false;
                        break;

                    default:
                        Console.WriteLine("Please write a valid command");
                        break;
                }
            } while (looping);


            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            
      
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            bool looping = true; 
            Queue<string> queue = new Queue<string>();

            do
            {
                Console.WriteLine("Menu:" +
                    "\nPress 1 to add to the queue" +
                    "\nPress 2 to remove from the queue" +
                    "\nPress r to return to the previous menu \n");
                string input = Console.ReadLine();

                switch (input)
                {
                        case "1":
                        Console.WriteLine("Adding..");
                        string queueAdd = Console.ReadLine();
                        queue.Enqueue(queueAdd); //Adds the input to the queue
                        Console.WriteLine($"{queueAdd} has joined the queue.\n");
                        break;
                        case "2":
                        if (queue.Count > 0) //Runs if the queue isnt empty
                        {
                            string queueRemoved = queue.Dequeue(); //Removes from the queue
                            Console.WriteLine($"{queueRemoved} has left the queue \n");
                        } else
                        {
                            Console.WriteLine("The queue is empty");
                        }
                        break;
                        case "r":
                        Console.WriteLine("Returning.. \n");
                        looping = false;
                        break;
                        default:
                        Console.WriteLine("Write a valid menu input..");
                        break;
                }


            } while (looping);
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<string> stack = new Stack<string>();
            bool looping = true;
            do
            {
                Console.WriteLine("Menu:\n" +
                    "Press 1 to add input to the stack\n" +
                    "Press 2 to remove from the stack\n" +
                    "Press 3 to reverse input\n" +
                    "press r to return to the previous menu\n");
                string input = Console.ReadLine();

                switch (input )
                {
                        case "1": //adds to the stack
                        Console.WriteLine("Adding..");
                        string stackAdd = Console.ReadLine();
                        stack.Push(stackAdd); //adds
                        break;

                        case "2": //Removes from the stack
                        if (stack.Count > 0) //Runs if the stack isnt empty
                        {
                         string popped = stack.Pop(); //According to FIFO removes from the stack
                            Console.WriteLine($"{popped} has been removed");
                        } else //if the stack is empty
                        {
                            Console.WriteLine("The stack is empty");
                        }
                        break;

                        case "3": //reverse input
                        ReverseText();
                        break;
                        case "r":
                        Console.WriteLine("Returning.. \n");
                        looping = false;
                        break;

                }

            } while (looping);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

        static void ReverseText()
        {
            Console.WriteLine("Enter a string to reverse:");
            string input = Console.ReadLine();

            Stack<char> reverseStack = new Stack<char>(); //Creates the stack for reverse

            foreach (char c in input) { reverseStack.Push(c); } //Pushes each character of the input onto the stack
            Console.WriteLine("Reversed string:");
            while (reverseStack.Count > 0) { Console.Write(reverseStack.Pop());
        }
            Console.WriteLine("\n");
    }
}
}

