using System;

namespace Cars.Domain.DomainExceptions
{
    public class InvalidBirthDateException: Exception
    {
        public InvalidBirthDateException(DateTime birthDate): base(ModifyMessage(birthDate))
        {
        }
        
        private static string ModifyMessage(DateTime birthDate)
        {
            return $"Invalid birth date {birthDate}.";
        }
    }

}