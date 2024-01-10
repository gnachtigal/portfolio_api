namespace portfolio_api.Models
{
    public class Profile
    {
        public Resume Resume { get; set; }
        public string Description { get; set; }
        public Role ActualRole { get; set; }
        public List<Role> PreviousRoles { get; set; }
        public List<Skill> Skills { get; set; }
        public string RawData { get; set; }
    }

    public class Resume
    {
        public string Data { get; set; }
    }

    public class Role
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }
    }
}
