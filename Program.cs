using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card_jigsaw_puzzle
{
    internal class Program
    {

        static void Main(string[] args)
        {
            {
                GameInfo();
                Console.WriteLine("Enter any key to play game");
                Console.ReadLine();
                Cards AIcards = new Cards();
                Cards Usercards = new Cards();
                //alloting Cards to AI
                Random randNum = new Random();
                AIcards.PowerOfCard = random(1, 6);
                AIcards.TypeOfCard = random(1, 4);
                //alloting Cards to AI            
                Usercards.PowerOfCard = random(1, 6);
                Usercards.TypeOfCard = random(1, 4);
                int  loss = 0, UserInput=0, time = 0;                
                while (true)
                {

                    Console.WriteLine("You have these cards");
                    PrintCards(Usercards.PowerOfCard, Usercards.TypeOfCard);

                    if (int.TryParse(Console.ReadLine(), out UserInput))
                    {

                        if (UserInput > AIcards.TypeOfCard.Length)
                        {
                            Console.WriteLine("ERROR");
                        }
                        else
                        {

                            int index = randNum.Next(0, AIcards.PowerOfCard.Length);
                            int temppower = AIcards.PowerOfCard[index];
                            int temptype = AIcards.TypeOfCard[index];
                            Console.ForegroundColor = ConsoleColor.Black;
                            int result = Result(temppower, temptype, Usercards.PowerOfCard[UserInput], Usercards.TypeOfCard[UserInput]);
                            Console.ResetColor();
                            //subracting cards from array
                            AIcards.PowerOfCard = ArraySub(AIcards.PowerOfCard, index);
                            AIcards.TypeOfCard = ArraySub(AIcards.TypeOfCard, index);
                            Usercards.PowerOfCard = ArraySub(Usercards.PowerOfCard, UserInput);
                            Usercards.TypeOfCard = ArraySub(Usercards.TypeOfCard, UserInput);
                            if (result > 1)
                            {
                                loss++;

                            }
                            time++;
                            if (time == 5)
                            {
                                time = 0;
                                if (loss >= 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Write("You lost");
                                    Console.ResetColor();
                                    Console.Write("\n");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.Write("you won");
                                    Console.ResetColor();
                                    Console.Write("\n");
                                }
                                Console.WriteLine("Do you want to play again (Y/N)");
                                string Willplay = Console.ReadLine().ToLower();
                                if (Willplay == "y")
                                {
                                    AIcards.PowerOfCard = random(1, 6);
                                    AIcards.TypeOfCard = random(1, 4);
                                    //alloting Cards to AI            
                                    Usercards.PowerOfCard = random(1, 6);
                                    Usercards.TypeOfCard = random(1, 4);
                                }else if (Willplay == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("no proper respone selected ");
                                    Console.WriteLine("EXIT  the game");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a correct string");
                    }
                }

                Console.WriteLine("thanks for playing my game");
                System.Threading.Thread.Sleep(1000);

            }


        }
        static int[] random(int max,int min)
        {
            Random randNum = new Random();
            int[] array=new int[5];
            for (int i = 0; i < 5; i++)
            {
                array[i] = randNum.Next(max, min);                
            }
            return array;

        }
        static int[] ArraySub(int[] arr,int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                // moving elements downwards, to fill the gap at [index]
                arr[a] = arr[a + 1];
            }
            // finally, let's decrement Array's size by one
            Array.Resize(ref arr, arr.Length - 1);
            return arr;
        }
            

        static int Result(int AIpower, int AItype, int userpower, int usertype)
        {
            // 1:Blue ice 2: Red fire 3:cyan wind
            if (AItype == usertype)
            {
               if(userpower == AIpower)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("tie");
                    Console.ResetColor();
                    Console.Write("\n");
                    return 0;
                }
                else if (userpower>AIpower)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("You won form the Ai's "+CheckType(AItype)+" power " + AIpower + "card");
                    Console.ResetColor();
                    Console.Write("\n");
                    return 1;

                }
                else 
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("You lost form the Ai's " + CheckType(AItype) + " power " + AIpower + "card");
                    Console.ResetColor();
                    Console.Write("\n");
                    return 2;

                }


            }
            else if (AItype == 1 && usertype == 2)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("You won form the Ai's Ice power " + AIpower + " card");
                Console.ResetColor();
                Console.Write("\n");
                return 1;

            }
            else if (AItype == 2 && usertype == 3)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("You won form the Ai's Wind power " + AIpower + " card");
                Console.ResetColor();
                Console.Write("\n");
                return 1;
            }
            else if (AItype == 3 && usertype == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("You won form the Ai's wind power " + AIpower + " card");
                Console.ResetColor();
                Console.Write("\n");
                return 1;
            }
            else if (AItype == 1 && usertype == 3)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("You lost form the Ai's Ice power " + AIpower + " card");
                Console.ResetColor();
                Console.Write("\n");
                return 2;
            }
            else if (AItype == 2 && usertype == 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("You lost form the Ai's fire power " + AIpower + " card");
                Console.ResetColor();
                Console.Write("\n");
                return 2;
            }
            else if (AItype == 3 && usertype == 2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("You lost form the Ai's wind power " + AIpower + " card");
                Console.ResetColor();
                Console.Write("\n");
                return 2;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("ERROR");
                Console.ResetColor();
                Console.Write("\n");
                return 3;
            }






        }
        static void PrintCards(int[] power, int[] type)
        {
            
            PrintMatterOfcard(type);
            PrintMatterOfcard(type);            
            //printing the power of card
            for (int i = 0; i < type.Length; i++)
            {
                TypeBackground(type[i]);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("**");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(power[i]);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("**  ");
                Console.ResetColor();
            }
            
            Console.Write("\n");
            PrintMatterOfcard(type);
            PrintMatterOfcard(type);
            for (int i = 0; i < type.Length; i++)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("  ");
                Console.Write(i );
                Console.Write("    ");
            }
            Console.ResetColor();
            Console.Write("\n");
        }
        static void PrintMatterOfcard(int[] type)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < type.Length; i++)
            {
                TypeBackground(type[i]);

                Console.Write("*****  ");
            }
            Console.ResetColor();

            Console.Write("\n");

        }
        static void TypeBackground(int Type)
        {
            switch (Type)
            {
                case 1:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
            }
        }
        static string CheckType(int Type)
        {            
            switch (Type)
            {
                case 1:
                    return "blue";                    
                case 2:
                    return "red";                    
                case 3:
                    return "cyan";
                default:
                    return "error";                   
            }
        }
        static void GameInfo()
        {
            Console.WriteLine("This is a  card game");
            Console.Write("There are 3 type of card :");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("Blue (Ice) ,");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("Red (Fire) ,");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("Cyan (Air) \n");
            Console.ResetColor();
            Console.WriteLine("Each card has it's own power denoted by a number (1-5).");
            Console.WriteLine("You will be given 5 card at start of Game ");
            Console.WriteLine("Same power card can be  compared as follows :");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("Blue (Ice) ");
            Console.ResetColor();
            Console.Write("Wins From");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("Cyan (Air) ");
            Console.ResetColor();
            Console.Write("Wins From");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("Red (Fire) ");
            Console.ResetColor();
            Console.Write("Wins From");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" Blue (Ice)  ");
            Console.ResetColor();
            Console.Write("\n");
        }
    }
}
