namespace DoStuff;

/// <summary>
///  this is the 'main' project for our extension, the core and client
///  are included in this project, and then this is project we add to 
///  the website. 
/// </summary>
/// <remarks>
///  having a core and client, means we can potentially have extensions
///  that only need core (no UI) and they don't have to include any of 
///  the client logic. 
///  
///  it also means we might have multiple clients (for multiple umbraco
///  client versions) that can all use the same core. 
/// </remarks>
public class DoStuff
{

}
