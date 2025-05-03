namespace TechXpress.Web.ViewModel
{
    public class UserManagementViewModel
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public string CurrentRole { get; set; }
        public List<string> AvailableRoles { get; set; } = new List<string>();
        public DateTime RegistrationDate { get; set; }

        public string GetRoleBadgeClass()
        {
            return CurrentRole.ToLower() switch
            {
                "admin" => "role-admin",
                "manager" => "role-manager",
                "user" => "role-user",
                _ => "role-other"
            };
        }

    }
}
