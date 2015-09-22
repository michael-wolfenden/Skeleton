//////////////////////////////////////////////////////////////////////
// EXTERNAL NUGET LIBRARIES
//////////////////////////////////////////////////////////////////////

#addin "Microsoft.Web.Administration"
#addin "Cake.IIS"

//////////////////////////////////////////////////////////////////////
// PRIVATE TASKS
//////////////////////////////////////////////////////////////////////

Task("__CreateApplicationPool")
    .Description("Create a ApplicationPool")
    .Does(() =>
{
    CreatePool(new ApplicationPoolSettings()
    {
        Name = projectName.ToLower() + "-application-pool",
        IdentityType = IdentityType.NetworkService,
        MaxProcesses = 1
    });
});

Task("__CreateIISWebSite")
    .Does(() =>
{
    CreateWebsite("localhost", new WebsiteSettings()
    {
        Name = projectName.ToLower(),
		BindingProtocol = "Https",
		Port = 443,
        HostName = projectName.ToLower() + ".localtest.me",
        PhysicalDirectory = @"D:\projects\Skeleton\src\Skeleton.WebHost",
		CertificateHash = GetBytes("ea55c8a35943e6893f6487fc572044865c802f7b"),
		CertificateStoreName = "Root",
        ApplicationPool = new ApplicationPoolSettings()
        {
	        Name = projectName.ToLower() + "-application-pool",
	        IdentityType = IdentityType.NetworkService,
	        MaxProcesses = 1
        }
    });
});

//////////////////////////////////////////////////////////////////////
// BUILD TASKS
//////////////////////////////////////////////////////////////////////

Task("__InitializeEnvironment")
    .IsDependentOn("__CreateIISWebSite");

public static byte[] GetBytes(string str)
{
    byte[] bytes = new byte[str.Length * sizeof(char)];
    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
    return bytes;
}

