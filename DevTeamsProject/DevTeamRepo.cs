using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();
        
        //DevTeam Create
        public void AddNewTeam(DevTeam team)
        {
            _devTeams.Add(team);
        }      


        //DevTeam Read
        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }


        //DevTeam Add Developer to Existing Team
        public bool UpdateDevTeam(string devTeamToUpdate, DevTeam developer)
        {
            DevTeam devTeam = GetDevTeamByID(devTeamToUpdate);

            if (devTeam != null)
            {

                //devTeam.ListOfDevs = developer.ListOfDevs;
                foreach (var dev in developer.ListOfDevs)
                {
                    devTeam.ListOfDevs.Add(dev);
                    
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete Developer from Existing Team
        public bool RemoveDevFromTeam(string devTeamToUpdate, DevTeam developer)
        {
            DevTeam devTeam = GetDevTeamByID(devTeamToUpdate);
            devTeam.ListOfDevs = developer.ListOfDevs;
            
            foreach (var dev in developer.ListOfDevs)
            {
                //Console.WriteLine(dev.DevID);
                devTeam.ListOfDevs.Remove(dev);
            }

            return true;
        }


        //DevTeam Delete
        public bool RemoveDevTeamFromList(string devTeamName)
        {
            DevTeam devTeam = GetDevTeamByID(devTeamName);

            if(devTeam == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(devTeam);

            if (initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamByID(string devID)
        {
            foreach (DevTeam team in _devTeams)
            {
                if(team.DevTeamName == devID)
                {
                    return team;
                }
            }

            return null;
        }


    }
}
