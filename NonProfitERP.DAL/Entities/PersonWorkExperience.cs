namespace PublicData.DAL.Entities
{
    public partial class PersonWorkExperience : Entity
    {
        public PersonWorkExperience()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties

        public int PersonId { get; set; }

        public int? OrganizationId { get; set; }

        public string OtherOrganization { get; set; }

        public int? WorkTypeId { get; set; }

        public string OtherWorkType { get; set; }

        public int? DepartmentId { get; set; }

        public string OtherDepartment { get; set; }

        public int? DesignationId { get; set; }

        public string OtherDesignation { get; set; }

        public int? FromYear { get; set; }

        public int? ToYear { get; set; }

        public string Specialization { get; set; }

        public bool? IsFreeLance { get; set; }

        public bool? IsFullTime { get; set; }

        public string LongText { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Detail DepartmentDetail { get; set; }

        public virtual Detail DesignationDetail { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Person Person { get; set; }

        public virtual Detail WorkTypeDetail { get; set; }

        #endregion

    }
}
