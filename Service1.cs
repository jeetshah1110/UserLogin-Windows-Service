using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
namespace UserLoginService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            
            
            
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Jeet\Desktop\UserInfo.txt",append:true))
            {


                WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                String username = wp.Identity.Name;
                sw.WriteLine("User Name: "+username+"        Login Time: "+ GetLastLoginToMachine(Environment.MachineName, username));
                

            }
        }

        protected override void OnStop()
        {
        }
        public static string GetLastLoginToMachine(string machineName, string userName)
        {
            string op = null;
            PrincipalContext c = new PrincipalContext(ContextType.Machine, machineName);
            UserPrincipal uc = UserPrincipal.FindByIdentity(c, userName);
            op = Convert.ToString(uc.LastLogon);
            return op;
        }
    }
}
