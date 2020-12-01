using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevTeamsProject;


namespace Program
{
    class ProgramUI
    {
        private readonly DeveloperRepo _developerRepo = new DeveloperRepo();
        private readonly DevTeamRepo _devTeamRepo = new DevTeamRepo();

        //Application start method
        public void RunApp()
        {
            SeedDevList();
            //SeedTeamList();
            UserMenu();
        }
        
        
        // Beginning Menu Method
        private void UserMenu()
        {
            bool userMenuLoop = true;
            while (userMenuLoop)
            {

                Console.WriteLine("  ****** Komodo Insurance Developer Team App ******\n\n");

                Console.Write("  What would you like to do? Enter corresponding number:\n" +
                    "  (1) Developer Teams Menu\n" +
                    "  (2) Developers Menu\n" +
                    "  (3) Pluralsight Access/License Check\n" +
                    "  (4) Exit Program\n\n" +
                    "     Enter number here --> ");

                // Grab user input
                string input = Console.ReadLine();

                //Switch statement for user choice
                switch (input)
                {
                    case "1":       //Developer Teams Menu                        
                        DeveloperTeamMenu();
                       
                        break;
                    case "2":        //Developers Menu 
                        DeveloperMenu();                           
                        break;
                    case "3":       //Pluralsight Access/License Check                         
                        PluralsightAccLicCheck();                          
                        break;
                    case "4":       //Exit Program Option                        
                        Console.WriteLine("\n EXIT PROGRAM");
                        userMenuLoop = false;
                        break;
                    default:        //Option for invalid choice                        
                        Console.WriteLine("\n Please choose a valid number option (1 - 4)");
                        break;
                }                
                    Console.WriteLine("\n Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();                
            }                       
        }

        //Developer Teams Menu
        private void DeveloperTeamMenu()            
        {
            Console.Clear();
            bool devTeamMenuLoop = true;
            while (devTeamMenuLoop)
            {
                Console.WriteLine(" ****** Developer Teams Menu ******\n");
                Console.Write("  What would you like to do? Enter corresponding number:\n" +
                        "  (1) See teams list\n" +
                        "  (2) Create a team\n" +
                        "  (3) Delete an existing team\n" +
                        "  (4) Add developer to an existing team\n" +
                        "  (5) Remove developer from an existing team\n" +
                        "  (6) Exit back to Main Menu\n\n" +
                        "     Enter number here --> ");

                // Grab user input
                string input = Console.ReadLine();

                //Switch statement for user choice
                switch (input)
                {
                    case "1":       //See teams list
                        SeeTeamsList();                        
                        break;
                    case "2":       //Create a new team                        
                        CreateNewTeam();                        
                        break;
                    case "3":        //Delete an existing team
                        DeleteAnExistingTeam();                        
                        break;
                    case "4":       //Add developer to an existing team                       
                        AddDevToTeam();                        
                        break;
                    case "5":       //Delete developer from an existing team
                        DeleteDevFromTeam();                        
                        break;
                    case "6":       //Exit back to main menu                        
                        Console.Clear();
                        Console.WriteLine(" Exit back to main menu");
                        devTeamMenuLoop = false;                        
                        break;
                    default:        //Option for invalid choice                        
                        Console.WriteLine(" Please choose a valid number option (1 - 5)");
                        break;
                }
                if (devTeamMenuLoop == true)
                {
                    Console.WriteLine("\n Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {                                       
                }                
            }//End of While loop            
        }

        
        private void SeeTeamsList()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeams();
           
            foreach (DevTeam team in listOfDevTeams)
            {
                Console.WriteLine($"\n {team.DevTeamName}: ");
                foreach (var dev in team.ListOfDevs)
                {
                    Console.WriteLine($" {dev.DevID}");
                }              
                
            }
        }

        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();
            Console.Write("\n Enter a team name: ");
            newDevTeam.DevTeamName = Console.ReadLine();
            _devTeamRepo.AddNewTeam(newDevTeam);

        }

        private void DeleteAnExistingTeam()
        {
            Console.Clear();
            SeeTeamsList();

            Console.Write("\n Enter the team name you wish to delete: ");
            string input = Console.ReadLine();

            bool wasDeleted = _devTeamRepo.RemoveDevTeamFromList(input);

            if(wasDeleted)
            {
                Console.WriteLine("\n The developer team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("\n The developer team could not be deleted.");
            }
        }
                
        private void AddDevToTeam()
        {
            DevTeam newDevTeam = new DevTeam();
            

            Console.Clear();
            SeeTeamsList();
            Console.WriteLine("\n Enter which team name you would like to add the developer to: ");
            string teamName = Console.ReadLine();

            Console.Write($" Enter the developer ID to add to {teamName}: ");
            string devIDToAddToDevList = Console.ReadLine();
            Developer devTeamByID = _developerRepo.FindDevByID(devIDToAddToDevList);
            newDevTeam.ListOfDevs.Add(devTeamByID);

            bool wasUpdated = _devTeamRepo.UpdateDevTeam(teamName, newDevTeam);
            if(wasUpdated)
            {
                Console.WriteLine("\n Team updated successfully");
            }
            else
            {
                Console.WriteLine("\n Team could not be updated");
            }            
        }

        private void DeleteDevFromTeam()
        {
            DevTeam newDevTeam = new DevTeam();


            Console.Clear();
            SeeTeamsList();
            Console.WriteLine("\n Enter which team name you would like to remove the developer from: ");
            string teamName = Console.ReadLine();

            Console.Write($" Enter the developer ID to remove from {teamName}: ");
            string devIDToRemoveFromDevList = Console.ReadLine();
            Developer devTeamByID = _developerRepo.FindDevByID(devIDToRemoveFromDevList);
            newDevTeam.ListOfDevs.Remove(devTeamByID);
           
            bool wasDeleted = _devTeamRepo.RemoveDevFromTeam(teamName, newDevTeam);
            if (wasDeleted)
            {
                Console.WriteLine("\n Team updated successfully");
            }
            else
            {
                Console.WriteLine("\n Team could not be updated");
            }
        }


        //DeveloperMenu()
        private void DeveloperMenu()
        {
            Console.Clear();
            bool devMenuLoop = true;
            while (devMenuLoop)
            {
                Console.WriteLine(" ****** Developer Menu ******\n");
                Console.Write("  What would you like to do? Enter corresponding number:\n" +
                        "  (1) Add a new developer\n" +
                        "  (2) Delete an existing developer\n" +    
                        "  (3) See developer list\n" +
                        "  (4) Update an existing developer by ID\n" +
                        "  (5) Exit back to Main Menu\n\n" +
                        "     Enter number here --> ");

                // Grab user input
                string input = Console.ReadLine();

                //Switch statement for user choice
                switch (input)
                {
                    case "1":       //Add a new developer                        
                        AddNewDev();
                        break;
                    case "2":        //Delete an existing developer
                        DeleteDev();                        
                        break;
                    case "3":       //See developer list
                        SeeDeveloperList();
                        break;
                    case "4":       //Update existing developer
                        UpdateDev();
                        break;
                    case "5":       //Exit back to main menu                        
                        Console.Clear();
                        Console.WriteLine("\n Exit back to main menu");
                        devMenuLoop = false;
                        break;
                    default:        //Option for invalid choice                        
                        Console.WriteLine("\n Please choose a valid number option (1 - 5)");
                        break;
                }
                if (devMenuLoop == true)
                {
                    Console.WriteLine("\n Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                }
            }//End of While loop
        }
        //AddNewDev()
        private void AddNewDev()
        {
            Developer newDeveloper = new Developer();

            Console.Write(" Enter developer first name: ");
            newDeveloper.FirstName = Console.ReadLine();

            Console.Write(" Enter developer last name: ");
            newDeveloper.LastName = Console.ReadLine();

            Console.Write(" Enter developer ID: ");
            newDeveloper.DevID = Console.ReadLine();

            Console.Write(" Does developer have access to Pluralsight? (Y/N): ");
            string pluralsightAccessString = Console.ReadLine().ToLower();

            if (pluralsightAccessString == "y")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
            }

            Console.Write(" Does developer have a Pluralsight license? (Y/N): ");
            string pluralsightLicense = Console.ReadLine().ToLower();

            if (pluralsightLicense == "y")
            {
                newDeveloper.PluralsightLicense = true;
            }
            else
            {
                newDeveloper.PluralsightLicense = false;
            }

            _developerRepo.AddDevToList(newDeveloper);
            
        }


        //DeleteDev()
        private void DeleteDev()
        {
            Console.Clear();
            Console.Write("\n Enter developer ID to delete: ");
            string devID = Console.ReadLine().ToLower();

            List<Developer> listOfDevs = _developerRepo.GetDevList();
            int counter = listOfDevs.Count;

            foreach (Developer developer in listOfDevs)
            {                
                if (developer.DevID.ToLower() == devID)
                {
                _developerRepo.RemoveDevFromList(developer.DevID);
                    Console.WriteLine("\n Developer deletion confirmed.");
                    break;
                }
                if (developer.DevID.ToLower() != devID.ToLower())
                {
                    counter--;
                    if (counter == 0)
                    {
                        Console.WriteLine($"\n {devID} could not be found");
                    }
                }
            }
        }


        //SeeDeveloperList()
        private void SeeDeveloperList()
        {
            Console.Clear();
            List<Developer> listOfDevs = _developerRepo.GetDevList();

            foreach(Developer developer in listOfDevs)
            {
                Console.WriteLine($"Name: {developer.FirstName} {developer.LastName}");
                Console.WriteLine($"DevID: {developer.DevID}");
                Console.WriteLine($"Team: {developer.TeamName}");
                Console.WriteLine($"Has Pluralsight Access? {developer.PluralsightAccess}");
                Console.WriteLine($"Has Pluralsight License? {developer.PluralsightLicense}\n\n");
            }
        }

        //Update existing developer
        private void UpdateDev()
        {
            Console.Clear();
            Console.Write(" Enter developer ID to update: ");
            string devID = Console.ReadLine();

            List<Developer> listOfDevs = _developerRepo.GetDevList();
            int counter = listOfDevs.Count;

            Developer newValue = new Developer();
            bool pluralsightValue = true;

            foreach (Developer developer in listOfDevs)
            {
                if(developer.DevID.ToLower() == devID.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine($" Here are the current values for {devID}:\n");
                    Console.WriteLine($" (1) Developer first name: {developer.FirstName}\n" +
                        $" (2) Developer last name: {developer.LastName}\n"+                       
                        $" (3) Developer ID: {developer.DevID}\n" +
                        $" (4) Developer Team: {developer.TeamName}\n" +
                        $" (5) Pluralsight access: {developer.PluralsightAccess}\n" +
                        $" (6) Pluralsight license: {developer.PluralsightLicense}\n\n");

                    Console.Write(" Enter the corresponding number for the item you would like to update: ");
                    string changeValue = Console.ReadLine();                    

                    string answer;
                    switch (changeValue)                        
                    {
                        case "1":
                            Console.Write(" Enter new first name: ");
                            newValue.FirstName = Console.ReadLine();
                            newValue.LastName = developer.LastName;
                            newValue.DevID = developer.DevID;
                            newValue.TeamName = developer.TeamName;
                            newValue.PluralsightAccess = developer.PluralsightAccess;
                            newValue.PluralsightLicense = developer.PluralsightLicense;
                            break;
                        case "2":
                            Console.Write(" Enter new last name: ");
                            newValue.FirstName = developer.FirstName;                            
                            newValue.LastName = Console.ReadLine();
                            newValue.DevID = developer.DevID;
                            newValue.TeamName = developer.TeamName;
                            newValue.PluralsightAccess = developer.PluralsightAccess;
                            newValue.PluralsightLicense = developer.PluralsightLicense;
                            break;
                        case "3":
                            Console.Write(" Enter new developer ID: ");
                            newValue.FirstName = developer.FirstName;
                            newValue.LastName = developer.LastName;                            
                            newValue.DevID = Console.ReadLine();
                            newValue.TeamName = developer.TeamName;
                            newValue.PluralsightAccess = developer.PluralsightAccess;
                            newValue.PluralsightLicense = developer.PluralsightLicense;
                            break;
                        case "4":
                            Console.Write(" Enter new team name: ");
                            newValue.FirstName = developer.FirstName;
                            newValue.LastName = developer.LastName;
                            newValue.DevID = developer.DevID;
                            newValue.TeamName = Console.ReadLine();                            
                            newValue.PluralsightAccess = developer.PluralsightAccess;
                            newValue.PluralsightLicense = developer.PluralsightLicense;
                            break;
                        case "5":
                            Console.Write(" Pluralsight access (Y/N): ");
                            answer = Console.ReadLine();
                            if (answer.ToLower() == "y")
                            {
                                newValue.FirstName = developer.FirstName;
                                newValue.LastName = developer.LastName;
                                newValue.DevID = developer.DevID;
                                newValue.TeamName = developer.TeamName;                                
                                newValue.PluralsightAccess = true;
                                newValue.PluralsightLicense = developer.PluralsightLicense;
                            }
                            else if (answer.ToLower() == "n")
                            {
                                newValue.FirstName = developer.FirstName;
                                newValue.LastName = developer.LastName;
                                newValue.DevID = developer.DevID;
                                newValue.TeamName = developer.TeamName;                                
                                newValue.PluralsightAccess = false;
                                newValue.PluralsightLicense = developer.PluralsightLicense;
                            }
                            else
                            {
                                Console.WriteLine("\n Invalid entry");
                                pluralsightValue = false;
                            }
                            break;
                        case "6":
                            Console.Write(" Pluralsight license (Y/N): ");
                            answer = Console.ReadLine();
                            if (answer.ToLower() == "y")
                            {
                                newValue.FirstName = developer.FirstName;
                                newValue.LastName = developer.LastName;
                                newValue.DevID = developer.DevID;
                                newValue.TeamName = developer.TeamName;
                                newValue.PluralsightAccess = developer.PluralsightAccess;
                                newValue.PluralsightLicense = true;
                                
                            }
                            else if (answer.ToLower() == "n")
                            {
                                newValue.FirstName = developer.FirstName;
                                newValue.LastName = developer.LastName;
                                newValue.DevID = developer.DevID;
                                newValue.TeamName = developer.TeamName;
                                newValue.PluralsightAccess = developer.PluralsightAccess;
                                newValue.PluralsightLicense = false;
                                
                            }
                            else
                            {
                                Console.WriteLine("\n Invalid entry");
                                pluralsightValue = false;
                            }
                            break;
                        default:
                            Console.WriteLine("\n Enter a valid number");
                            break;
                    }
                }
                if (developer.DevID.ToLower() != devID.ToLower())
                {
                    counter--;
                    if (counter == 0)
                    {
                        Console.WriteLine($"\n {devID} could not be found");
                    }
                }
            }
            if (pluralsightValue == true)
            {
                bool wasUpdated = _developerRepo.UpdateDeveloper(devID, newValue);
                if (wasUpdated)
                {
                    Console.WriteLine("\n Value updated");
                }
                else
                {
                    Console.WriteLine("\n Value could not be updated");
                }
            }
            else
            {
                Console.WriteLine("\n Return to menu and enter valid option (Y/N)");
            }
        }



        //PluralsightAccLicCheck()
        private void PluralsightAccLicCheck()
        {
            Console.Clear();
            Console.Write(" Enter developer ID: ");
            string devID = Console.ReadLine();            

            List<Developer> listOfDevs = _developerRepo.GetDevList();
            int counter = listOfDevs.Count;

            foreach (Developer developer in listOfDevs)
            {
                if(developer.DevID.ToLower() == devID.ToLower())
                {
                    if(developer.PluralsightAccess == true && developer.PluralsightLicense == true)
                    {
                        Console.WriteLine($" {developer.DevID}\n" +
                            " Pluralsight access: YES\n" +
                            " Pluralsight license: YES");
                    }
                    else if(developer.PluralsightAccess == true && developer.PluralsightLicense == false)
                    {
                        Console.WriteLine($" {developer.DevID}\n" +
                           " Pluralsight access: YES\n" +
                           " Pluralsight license: NO");
                    }
                    else if(developer.PluralsightAccess == false && developer.PluralsightLicense == true)
                    {
                        Console.WriteLine($" {developer.DevID}\n" +
                           " Pluralsight access: NO\n" +
                           " Pluralsight license: YES");
                    }
                    else if(developer.PluralsightAccess == false && developer.PluralsightLicense == false)
                    {
                        Console.WriteLine($" {developer.DevID}\n" +
                            " Pluralsight access: NO\n" +
                            " Pluralsight license: NO");
                    }                    
                }
                if(developer.DevID.ToLower() != devID.ToLower())
                {
                    counter--;
                    if(counter == 0)
                    {
                        Console.WriteLine($" {devID} could not be found");
                    }
                }                
            }
           



        }


        //Seed Developer List
        private void SeedDevList()
        {
            Developer dev1 = new Developer("Keith", "Anderson", "KA1345", "Damage Inc", true, true);
            Developer dev2 = new Developer("Bill", "Clark", "BC1200", "Damage Inc", true, false);
            Developer dev3 = new Developer("Rachel", "Herron", "RH1200", "Absolutely Fabulous", true, true);
            Developer dev4 = new Developer("Gretchen", "Allnut", "GA1123", "Absolutely Fabulous", true, false);
            Developer dev5 = new Developer("Matt", "Hobbs", "MH5623", "Brad Pitts Crew", false, true);
            Developer dev6 = new Developer("Lindsay", "Hobbs", "LH5623", "Brad Pitts Crew", true, true);
            Developer dev7 = new Developer("Sara", "Alsop", "SA3455", "Spanish Connection", false, true);
            Developer dev8 = new Developer("Dan", "Alsop", "DA3455", "Spanish Connection", true, false);
            _developerRepo.AddDevToList(dev1);
            _developerRepo.AddDevToList(dev2);
            _developerRepo.AddDevToList(dev3);
            _developerRepo.AddDevToList(dev4);
            _developerRepo.AddDevToList(dev5);
            _developerRepo.AddDevToList(dev6);
            _developerRepo.AddDevToList(dev7);
            _developerRepo.AddDevToList(dev8);

        }        
    }
}
