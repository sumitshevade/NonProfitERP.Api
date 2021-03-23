using AutoMapper;
using System;
using PublicData.Application.Mappings;
using System.Collections.Generic;
using PublicData.DAL.Entities;

namespace PublicData.Application.Shared
{
    public partial class PersonModel : IMapFrom<Person>
    {
        public PersonModel()
        {
            //DepartmentHead = new HashSet<DepartmentHead>();
            PersonAchievement = new HashSet<PersonAchievement>();
            PersonAddress = new HashSet<PersonAddress>();
            PersonContact = new HashSet<PersonContact>();
            PersonDisability = new HashSet<PersonDisability>();
            PersonEducation = new HashSet<PersonEducation>();
            PersonFamilyDetail = new HashSet<PersonFamilyDetail>();
            PersonHealthDetail = new HashSet<PersonHealthDetail>();
            PersonHobbyFavorite = new HashSet<PersonHobbyFavorite>();
            PersonLanguage = new HashSet<PersonLanguage>();
            PersonPrivateInformation = new HashSet<PersonPrivateInformation>();
            PersonSocialMediaAccount = new HashSet<PersonSocialMediaAccount>();
            PersonWorkExperience = new HashSet<PersonWorkExperience>();
            //Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string LoginId { get; set; }
        public int PersonTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public char Gender { get; set; }
        public string LongText { get; set; }
        public string Keywords { get; set; }
        public bool IsWorker { get; set; }
        public int WorkFrequencyId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? JoinedAsId { get; set; }
        public int? CountryId { get; set; }
        public bool IsActive { get; set; }

        public virtual Country Country { get; set; }
        public virtual Detail PersonType { get; set; }
        public virtual Detail WorkFrequency { get; set; }
        //public virtual ICollection<DepartmentHead> DepartmentHead { get; set; }
        public virtual ICollection<PersonAchievement> PersonAchievement { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<PersonContact> PersonContact { get; set; }
        public virtual ICollection<PersonDisability> PersonDisability { get; set; }
        public virtual ICollection<PersonEducation> PersonEducation { get; set; }
        public virtual ICollection<PersonFamilyDetail> PersonFamilyDetail { get; set; }
        public virtual ICollection<PersonHealthDetail> PersonHealthDetail { get; set; }
        public virtual ICollection<PersonHobbyFavorite> PersonHobbyFavorite { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguage { get; set; }
        public virtual ICollection<PersonPrivateInformation> PersonPrivateInformation { get; set; }
        public virtual ICollection<PersonSocialMediaAccount> PersonSocialMediaAccount { get; set; }
        public virtual ICollection<PersonWorkExperience> PersonWorkExperience { get; set; }
        //public virtual ICollection<Ticket> Ticket { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonModel>();
        }
    }
}
