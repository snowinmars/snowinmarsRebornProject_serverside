using System;

namespace Simr.Services
{
    public class Alergy
    {
        public string DoctorName { get; }

        public string substantionName { get; }

        private int customSubstantionID { get; set; }

        private int diagnosedByDoctorId { get; set; }

        private Guid memesSubstantionID { get; set; }

        public Alergy(int diagnosedByDoctorId, Guid memesSubstantionID) : this(diagnosedByDoctorId)
        {
            this.memesSubstantionID = memesSubstantionID;
            this.substantionName = GetSubstantionNameFromMemesTableById(memesSubstantionID);
        }

        public Alergy(int diagnosedByDoctorId, int customSubstantionID) : this(diagnosedByDoctorId)
        {
            if (customSubstantionID == 0)
            {
                throw new InvalidArgumentException();
            }
            this.customSubstantionID = customSubstantionID;
            this.substantionName = GetSubstantionNameFromCustomTableById(memesSubstantionID);
        }

        private Alergy(int diagnosedByDoctorId)
        {
            if (diagnosedByDoctorId == 0)
            {
                throw new InvalidArgumentException();
            }
            this.diagnosedByDoctorId = diagnosedByDoctorId;
            this.DoctorName = GetDoctorNameById(diagnosedByDoctorId);
        }

        public string ToString()
        {
            string result = "Patient has allergy on" + substantionName + " Diagnosed by doctor " + DoctorName;
            if (customSubstantionID != 0)
            {
                result += "taken from custom list";
            }
            else
            {
                result += "taken from memes list";
            }
            return result;
        }

        private string GetDoctorNameById(int i)
        {
            throw new NotImplementedException();
        }

        private string GetSubstantionNameFromCustomTableById(Guid memesSubstantionId)
        {
            throw new NotImplementedException();
        }

        private string GetSubstantionNameFromMemesTableById(Guid memesSubstantionId)
        {
            throw new NotImplementedException();
        }
    }
}