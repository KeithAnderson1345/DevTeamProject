using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        // DevTeam POCO

        public string DevTeamName { get; set; }
        public string DeveloperID { get; set; }
        public List<Developer> ListOfDevs { get; set; } = new List<Developer>();


        public DevTeam() { }
        public DevTeam(string devTeamName, string developerID, List<Developer> listofdevs)
        {
            DevTeamName = devTeamName;
            DeveloperID = developerID;
            ListOfDevs = listofdevs;
        }
    }
}
