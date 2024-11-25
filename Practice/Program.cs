using Portal;
try
{
    Config.CurrentEnv = Env.Dev;
    Portal.Portal portal = new Portal.Portal();
    portal.ShowDashboard();
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}



