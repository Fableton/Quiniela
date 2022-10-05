using Castle.Core.Internal;
using Entities;
using Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class Players
    {

        public static bool IsUserInActivity(int playerId, string activityId, QuinielaContext quinielaContext)
        {
            bool isValid = false;
            Player player = quinielaContext.Players.Find(playerId);
            if (player != null)
            {
                if (player.Rols.Any(r => r.IsRoot))
                {
                    isValid = true;
                }
                else
                {
                    if (activityId.IsNullOrEmpty())
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = player.Rols.Any(r => r.Activities.Any(a => a.Id == activityId));
                    }
                }
            }

            return isValid;
        }
    }
}
