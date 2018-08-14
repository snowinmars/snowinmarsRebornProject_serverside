using System;

namespace Simr.Services
{
    public class Allergy
    {
        public string DoctorName { get; set; }

        public string substantionName { get; set; }

        private int customSubstantionId { get; set; }

        private int diagnosedByDoctorId { get; set; }

        private Guid memesSubstantionId { get; set; }

        public Allergy(int diagnosedByDoctorId, Guid memesSubstantionId) : this(diagnosedByDoctorId, memesSubstantionId, null)
        {
        }

        public Allergy(int diagnosedByDoctorId, int customSubstantionId) : this(diagnosedByDoctorId, null, customSubstantionId)
        {
        }

        private Allergy(int diagnosedByDoctorId, Guid? memesSubstantionId, int? customSubstantionId)
        {
            Validate(memesSubstantionId, customSubstantionId);

            if (memesSubstantionId.HasValue)
            {
                SetMemes();
            }

            if (customSubstantionId.HasValue)
            {
                SetCustom(customSubstantionId);
            }

            if (diagnosedByDoctorId == 0)
            {
                throw new InvalidArgumentException();
            }

            SetDoctor(diagnosedByDoctorId);
        }

        private void SetDoctor(int diagnosedByDoctorId)
        {
            this.diagnosedByDoctorId = diagnosedByDoctorId;
            this.DoctorName = GetDoctorNameById(diagnosedByDoctorId);
        }

        private void SetCustom(int? customSubstantionId)
        {
            if (customSubstantionId == 0)
            {
                throw new InvalidArgumentException();
            }

            this.customSubstantionId = customSubstantionId.Value;
            this.substantionName = GetSubstantionNameFromCustomTableById(customSubstantionId.Value);
        }

        private void SetMemes()
        {
            this.memesSubstantionId = this.memesSubstantionId;
            this.substantionName = GetSubstantionNameFromMemesTableById(this.memesSubstantionId);
        }

        private static void Validate(Guid? memesSubstantionId, int? customSubstantionId)
        {
            if ((memesSubstantionId.HasValue && customSubstantionId.HasValue) ||
                            (!memesSubstantionId.HasValue && !customSubstantionId.HasValue))
            {
                throw new InvalidOperationException();
            }
        }

        public string ToString()
        {
            string result = $"Patient has allergy on{substantionName} Diagnosed by doctor {DoctorName}";

            if (customSubstantionId != 0)
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

        private string GetSubstantionNameFromCustomTableById(int customSubstantionId)
        {
            throw new NotImplementedException();
        }

        private string GetSubstantionNameFromMemesTableById(Guid memesSubstantionId)
        {
            throw new NotImplementedException();
        }
    }

    internal class InvalidArgumentException : Exception
    {
    }
}