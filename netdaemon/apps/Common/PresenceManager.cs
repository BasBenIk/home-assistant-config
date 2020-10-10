using System;
using System.Threading.Tasks;
using NetDaemon.Common.Reactive;
using System.Reactive.Linq;
/// <summary>
///     App docs
/// </summary>
public static class PresenceManager
{
    public static bool AnyoneHome(this NetDaemonRxApp app)
    {
        try
        {
            var isa_location = app.State(Isa.PersonEntity)?.State?.ToString()?.ToLower();
            var stefan_location = app.State(Stefan.PersonEntity)?.State?.ToString()?.ToLower();
            if (isa_location != null || stefan_location != null)
            {
                if (stefan_location == PresenceStatus.Home || stefan_location == PresenceStatus.JustArrived
                || isa_location == PresenceStatus.Home || isa_location == PresenceStatus.JustArrived)
                {
                    return true;
                }
                else return false;
            }
            // return true if null, assume someone could be home
            app.Log($"A person returned null as location state, assuming someone is home.");
            return true;
        }
        catch (System.Exception e)
        {
            // return true if something goes wrong, assume someone could be home
            app.Log($"Error: {e}");
            return true;
        }
    }
    public static bool StefanHome(this NetDaemonRxApp app)
    {
        try
        {
            var stefan_location = app.State(Stefan.PersonEntity)?.State?.ToString()?.ToLower();
            if (stefan_location != null)
            {
                if (stefan_location == PresenceStatus.Home || stefan_location == PresenceStatus.JustArrived)
                {
                    return true;
                }
                else return false;
            }
            // return true if null, assume someone could be home
            app.Log($"Stefan returned null as location state, assuming someone is home.");
            return true;
        }
        catch (System.Exception e)
        {
            // return true if something goes wrong, assume someone could be home
            app.Log($"Error: {e}");
            return true;
        }
    }

        public static bool IsaHome(this NetDaemonRxApp app)
    {
        try
        {
            var isa_location = app.State(Isa.PersonEntity)?.State?.ToString()?.ToLower();
            if (isa_location != null)
            {
                if (isa_location == PresenceStatus.Home || isa_location == PresenceStatus.JustArrived)
                {
                    return true;
                }
                else return false;
            }
            // return true if null, assume someone could be home
            app.Log($"Isa returned null as location state, assuming someone is home.");
            return true;
        }
        catch (System.Exception e)
        {
            // return true if something goes wrong, assume someone could be home
            app.Log($"Error: {e}");
            return true;
        }
    }
    public static bool AnyoneJustArrived(this NetDaemonRxApp app)
        {
            try
            {
                var isa_location = app.State(Isa.PersonEntity)?.State?.ToString()?.ToLower();
                var stefan_location = app.State(Stefan.PersonEntity)?.State?.ToString()?.ToLower();
                if (isa_location != null || stefan_location != null)
                {
                    if (stefan_location == PresenceStatus.JustArrived
                    || isa_location == PresenceStatus.JustArrived)
                    {
                        return true;
                    }
                    else return false;
                }
                // return true if null, assume someone could be home
                app.Log($"A person returned null as location state, assuming someone is home.");
                return true;
            }
            catch (System.Exception e)
            {
                // return true if something goes wrong, assume someone could be home
                app.Log($"Error: {e}");
                return true;
            }
        }
}