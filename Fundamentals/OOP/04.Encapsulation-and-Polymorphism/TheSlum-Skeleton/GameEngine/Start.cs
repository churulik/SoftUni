using System;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    public class Start : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
                default:
                    Console.WriteLine("Enter valid comand:");
                    Console.ReadLine();
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            switch (inputParams[1])
            {
                case "warrior":
                    var warrior = new Warrior(inputParams[2], 
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5]));
                    this.characterList.Add(warrior);
                    break;
                case "mage":
                    var mage = new Mage(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5]));
                    this.characterList.Add(mage);
                    break;
                case "healer":
                    var healer = new Healer(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5]));
                    this.characterList.Add(healer);
                    break;
                default:
                    Console.WriteLine("Enter valid character:");
                    Console.ReadLine();
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            var character = GetCharacterById(inputParams[1]);
            switch (inputParams[2])
            {
                case "axe":
                    var axe = new Axe(inputParams[3]);
                    character.AddToInventory(axe);
                    break;
                case "shield":
                    var shield = new Shield(inputParams[3]);
                    character.AddToInventory(shield);
                    break;
                case "pill":
                    var pill = new Pill(inputParams[3], 0, 0);
                    character.AddToInventory(pill);
                    break;
                case "injection":
                    var injection = new Injection(inputParams[3], 0, 0);
                    character.AddToInventory(injection);
                    break;
                default:
                    Console.WriteLine("Enter valid character:");
                    Console.ReadLine();
                    break;
            }
        }

    }
}