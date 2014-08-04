using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using Ripl.Model;

namespace Ripl
{
    public class Program
    {
        private static Applicant ParseApplicant(CsvReader csvReader)
        {
            Applicant a = new Applicant();

            a.StudentFirstName = csvReader.GetField<string>("Student First Name");
            a.StudentMiddleName = csvReader.GetField<string>("Student Middle Name");
            a.StudentLastName = csvReader.GetField<string>("Student Last Name");
            a.StudentBirthday = Convert.ToDateTime(csvReader.GetField<string>("Student Birthday"));
            a.StudentGender = ParseGender(csvReader.GetField<string>("Student Gender"));

            a.GuardianFirstName = csvReader.GetField<string>("Guardian First Name");
            a.GuardianLastName = csvReader.GetField<string>("Guardian Last Name");
            a.GuardianPhoneNumber = csvReader.GetField<string>("Guardian Phone Number");
            a.GuardianEmailAddress = csvReader.GetField<string>("Guardian E-mail Address");
            a.GuardianRelationshipToStudent = csvReader.GetField<string>("Guardian Relationship to Student");

            a.StreetAddress = csvReader.GetField<string>("Street Address");
            a.ZipCode = csvReader.GetField<string>("Zip Code");
            a.District = csvReader.GetField<string>("District of Residency");
            a.NumHouseholdMembers = int.Parse(csvReader.GetField<string>("Household Members"));
            a.AnnualHouseholdIncomeRange = csvReader.GetField<string>("Annual Income");
            a.AnnualHouseholdIncome = csvReader.GetField<string>("Household Income Amount");

            return a;
        }

        private static string EscapeSchoolName(string schoolName)
        {
            return schoolName.Replace("@","at").Replace('/','-');
        }

        private static Applicant.Gender ParseGender(string genderStr)
        {
            if (genderStr.Equals("MALE", StringComparison.InvariantCultureIgnoreCase)) 
            {
                return Applicant.Gender.MALE;
            }

            return Applicant.Gender.FEMALE;
        }

        public static void Main(string[] args)
        {
            // Arguments
            string inputCsvFilePath = args[0];
            string outputDirPath = args[1];

            // Store everything in...
            Dictionary<string, School> schoolDict = new Dictionary<string, School>();

            // Read the CSV
            using(StreamReader textReader = new StreamReader(inputCsvFilePath))
            {
                CsvReader csvReader = new CsvReader(textReader);
                csvReader.Configuration.SkipEmptyRecords = true;
                csvReader.Configuration.TrimFields = true;

                while(csvReader.Read())
                {
                    Applicant applicant = ParseApplicant(csvReader);

                    // Add student to each school
                    string schoolNames = csvReader.GetField<string>("Schools");
                    foreach( string schoolName in schoolNames.Split(','))
                    {
                        string trimmedSchoolName = schoolName.Trim();
                        if(!schoolDict.ContainsKey(schoolName))
                        {
                            School school = new School(trimmedSchoolName);
                            schoolDict[trimmedSchoolName] = school;
                            Console.WriteLine("School: {0}", trimmedSchoolName);
                        }

                        schoolDict[trimmedSchoolName].Applicants.Add(applicant);
                        Console.WriteLine("Applicant: {0}", applicant.StudentFirstName);
                    }
                }
            }

            // Create a CSV for each school
            foreach(string schoolName in schoolDict.Keys)
            {
                string filePath = outputDirPath + "\\" + EscapeSchoolName(schoolName) + ".csv";
                using (StreamWriter textWriter = new StreamWriter(filePath))
                {
                    CsvWriter csvWriter = new CsvWriter(textWriter);
                    csvWriter.WriteRecords(schoolDict[schoolName].Applicants);
                }
            }
        }
    }
}
