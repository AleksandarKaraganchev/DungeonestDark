using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonestDark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string[] dungeonRooms = Console.ReadLine().Split('|');
            int health = 100;
            int coins = 0;
            bool isDead = false;
            int roomCount = 0;
            foreach (string room in dungeonRooms)
            {
                roomCount++;
                string[] roomParts = room.Split();
                string firstPart = roomParts[0];
                int n = int.Parse(roomParts[1]);
                //if (roomParts.Length < 2 || !int.TryParse(roomParts[1], out value)) //int.TryParse(roomParts[1], out n) - чрез него проверяваме дали втория елемент на масива roomParts може да бъде успешно парснат като int
                //{
                //    Console.WriteLine("Invalid input!");
                //    return;
                //}
                if (firstPart == "potion")
                {
                    int healing = n;
                    int initialHealth = health;
                    health += healing;
                    if (health > 100)
                    {
                        health = 100;
                    }
                    Console.WriteLine($"You healed for {health - initialHealth} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else
                {
                    if (firstPart == "chest")
                    {
                        int foundCoins = n;
                        coins += foundCoins;
                        Console.WriteLine($"You found {foundCoins} coins.");
                    }
                    else//this else is for monsters
                    {
                        string monsterName = firstPart;
                        int monsterAttack = n;
                        health -= monsterAttack;

                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {monsterName}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {monsterName}.");
                            Console.WriteLine($"Best room: {roomCount}");
                            isDead = true;
                            break;
                        }
                    }
                }
            }
            if (!isDead)
            {
                Console.WriteLine($"Best room: {roomCount}");
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }
            
        }
    }
}
