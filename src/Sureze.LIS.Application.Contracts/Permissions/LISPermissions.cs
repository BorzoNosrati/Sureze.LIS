namespace Sureze.LIS.Permissions;

public static class LISPermissions
{
    public const string GroupName = "LIS";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";


    public static class Patients
    {
        public const string Default = GroupName + ".Patient";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
