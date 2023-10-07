using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    abstract class Worker
    {
        public string Name;
        public string Position;
        public string WorkDay;

        public Worker(string name)
        {
            Name = name;
        }

        protected void Call()
        {
            WorkDay += "Called ";
        }
        protected void WriteCode()
        {
            WorkDay += "WritedCode ";
        }
        protected void Relax()
        {
            WorkDay += "Relaxed ";
        }

        protected abstract void FillWorkDay();
    }

    class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            Position = "Developer";
            FillWorkDay();
        }

        protected override void FillWorkDay()
        {
            WriteCode();
            Call();
            Relax();
            WriteCode();
        }
    }

    class Manager : Worker
    {
        private Random r = new Random();
        public Manager(string name) : base(name)
        {
            Position = "Manager";
            FillWorkDay();
        }

        protected override void FillWorkDay()
        {
            int repeatCount = r.Next(10);
            for (int i = 0; i < repeatCount; i++)
                Call();
            Relax();
            repeatCount = r.Next(5);
            for (int i = 0; i < repeatCount; i++)
                Call();
        }
    }

    class Team
    {
        private List<Worker> MemberList = new List<Worker>();
        public string Name;
        public Team(string name)
        {
            Name = name;
        }

        public void AddMember(Worker newMember)
        {
            MemberList.Add(newMember);
        }
        public void TeamInfo()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Team: " + Name);
            for (int i = 0; i < MemberList.Count; i++)
            {
                Console.WriteLine(MemberList[i].Name);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        public void AdditionalTeamInfo()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Team: " + Name);
            for (int i = 0; i < MemberList.Count; i++)
            {
                Console.Write(MemberList[i].Name);
                Console.Write(", "); 
                Console.Write(MemberList[i].Position);
                Console.Write(", "); 
                Console.WriteLine(MemberList[i].WorkDay);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter team name:");
            string userInput = Console.ReadLine();
            Team userTeam = new Team(userInput);
            bool userConfirms = true;
            string workerName;
            int failCount = 0;
            Console.WriteLine("\nEnter worker name:");
            while ((failCount < 1) & userConfirms)
            {
                userInput = Console.ReadLine();
                workerName = userInput;
                Console.WriteLine("\nEnter position of your worker (M/D):");
                userInput = Console.ReadLine().Trim();
                if (userInput == "M")
                {
                    Manager userWorker = new Manager(workerName);
                    userTeam.AddMember(userWorker);
                }
                else if (userInput == "D")
                {
                    Developer userWorker = new Developer(workerName);
                    userTeam.AddMember(userWorker);
                }
                else
                {
                    Console.WriteLine("There are only Manager and Developer.");
                    failCount++;
                }
                if (failCount < 1)
                {
                    Console.WriteLine("\nEnter 'y' to continue:");
                    userInput = Console.ReadLine().Trim();
                    if (userInput == "y")
                    {
                        userConfirms = true;
                        Console.WriteLine("\nEnter worker name:");
                    }
                    else
                    {
                        userConfirms = false;
                    }
                }
            }
            userTeam.TeamInfo();
            Console.WriteLine("\nEnter 'y' to additional info:");
            userInput = Console.ReadLine().Trim();
            if (userInput == "y")
                userConfirms = true;
            else
                userConfirms = false;
            if (userConfirms) userTeam.AdditionalTeamInfo();
        }
    }
}
