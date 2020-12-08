namespace MVC.Services.Email
{
  /// <summary>
  /// Class EmailOptions.
  /// Implements access to Mailtrap config data
  /// </summary>
  public class EmailOptions
  {
    /// <summary>
    /// MailHost
    /// </summary>
    public string MailHost { get; set; }

    /// <summary>
    /// MailPort
    /// </summary>
    public string MailPort { get; set; }

    /// <summary>
    /// MailUserName
    /// </summary>
    public string MailUserName { get; set; }

    /// <summary>
    /// MailPassword
    /// </summary>
    public string MailPassword { get; set; }
  }
}
