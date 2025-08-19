using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKNDRIVE
{
    public static class UserSession
    {
        public static int UserId { get; private set; }
        public static string Fullname { get; private set; }

        public static void SetCurrentUser(int userId, string fullname)
        {
            UserId = userId;
            Fullname = fullname;
        }

        public static void Clear()
        {
            UserId = 0;
            Fullname = null;
        }
    }
}
