﻿using System;
using System.Collections.Generic;
using CsvHelper;

namespace Ripl.Model
{

    public class Applicant
    {
        public enum Gender { MALE, FEMALE };
        
        // Student info
        string studentFirstName;
        string studentMiddleName;
        string studentLastName;
        DateTime studentBirthday;
        Gender studentGender;

        // Guardian info
        string guardianFirstName;
        string guardianLastName;
        string guardianPhoneNumber;
        string guardianEmailAddress;
        string guardianRelationshipToStudent;

        // Household info
        string streetAddress;
        string annualHouseholdIncomeRange;
        string annualHouseholdIncome;
        string district; // city
        string zipCode;
        int numHouseholdMembers;

        public string StudentFirstName
        {
            get { return studentFirstName; }
            set { studentFirstName = value; }
        }

        public string StudentMiddleName
        {
            get { return studentMiddleName; }
            set { studentMiddleName = value; }
        }

        public string StudentLastName
        {
            get { return studentLastName; }
            set { studentLastName = value; }
        }

        public DateTime StudentBirthday
        {
            get { return studentBirthday; }
            set { studentBirthday = value; }
        }
        public Gender StudentGender
        {
            get { return studentGender; }
            set { studentGender = value; }
        }

        public string GuardianFirstName
        {
            get { return guardianFirstName; }
            set { guardianFirstName = value; }
        }

        public string GuardianLastName
        {
            get { return guardianLastName; }
            set { guardianLastName = value; }
        }

        public string GuardianPhoneNumber
        {
            get { return guardianPhoneNumber; }
            set { guardianPhoneNumber = value; }
        }

        public string GuardianEmailAddress
        {
            get { return guardianEmailAddress; }
            set { guardianEmailAddress = value; }
        }

        public string GuardianRelationshipToStudent
        {
            get { return guardianRelationshipToStudent; }
            set { guardianRelationshipToStudent = value; }
        }

        public string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }

        public string District
        {
            get { return district; }
            set { district = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public int NumHouseholdMembers
        {
            get { return numHouseholdMembers; }
            set { numHouseholdMembers = value; }
        }

        public string AnnualHouseholdIncomeRange
        {
            get { return annualHouseholdIncomeRange; }
            set { annualHouseholdIncomeRange = value; }
        }

        public string AnnualHouseholdIncome
        {
            get { return annualHouseholdIncome; }
            set { annualHouseholdIncome = value; }
        }
    }
}
