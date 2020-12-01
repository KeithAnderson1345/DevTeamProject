using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDevToList(Developer developer)
        {
            _developerDirectory.Add(developer);
        }

        //Developer Read
        public List<Developer> GetDevList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateDeveloper(string originalValue, Developer newValue)
        {
            Developer oldValue = FindDevByID(originalValue);

            if (oldValue != null)
            {
                oldValue.FirstName = newValue.FirstName;
                oldValue.LastName = newValue.LastName;
                oldValue.DevID = newValue.DevID;
                oldValue.TeamName = newValue.TeamName;
                oldValue.PluralsightAccess = newValue.PluralsightAccess;
                oldValue.PluralsightLicense = newValue.PluralsightLicense;

                return true;
            }
            else
            {
                return false;
            }

        }




        //Developer Delete
        public bool RemoveDevFromList(string devID)
        {
            Developer idToRemove = FindDevByID(devID);

            if (idToRemove == null)
            {
                return false;
            }

            int devlistCount = _developerDirectory.Count;
            _developerDirectory.Remove(idToRemove);

            if (devlistCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Developer Helper (Get Developer by ID)
        public Developer FindDevByID(string devID)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.DevID.ToLower() == devID.ToLower())
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
