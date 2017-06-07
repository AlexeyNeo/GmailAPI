using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;

// ...

public class MyClass
{

    // ...

    /// <summary>
    /// List all Messages of the user's mailbox matching the query.
    /// </summary>
    /// <param name="service">Gmail API service instance.</param>
    /// <param name="userId">User's email address. The special value "me"
    /// can be used to indicate the authenticated user.</param>
    /// <param name="query">String used to filter Messages returned.</param>
    public static List<Message> ListMessages(GmailService service, String userId, String query)
    {
        List<Message> result = new List<Message>();
        UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
        request.Q = query;

        do
        {
            try
            {
                ListMessagesResponse response = request.Execute();
                result.AddRange(response.Messages);
                request.PageToken = response.NextPageToken;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        } while (!String.IsNullOrEmpty(request.PageToken));

        return result;
    }

    // ...
     public static Message GetMessage(GmailService service, String userId, String messageId)
  {
      try
      {
          return service.Users.Messages.Get(userId, messageId).Execute();
      }
      catch (Exception e)
      {
          Console.WriteLine("An error occurred: " + e.Message);
      }

      return null;
  }

  // ...

}
