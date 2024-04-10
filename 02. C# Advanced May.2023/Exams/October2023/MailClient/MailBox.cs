using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Capacity > Inbox.Count)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            foreach (Mail mail in Inbox)
            {
                if (mail.Sender == sender)
                {
                    return Inbox.Remove(mail);
                }
            }

            return false;
        }

        public int ArchiveInboxMessages()
        {
            int mailsToMove = Inbox.Count;

            Archive.AddRange(Inbox);
            Inbox.Clear();

            return mailsToMove;
        }

        public string GetLongestMessage()
        {
            Mail longestMail = Inbox[0];
            foreach (Mail mail in Inbox)
            {
                if (mail.Body.Length > longestMail.Body.Length)
                {
                    longestMail = mail;
                }
            }

            return longestMail.ToString().Trim();
        }

        public string InboxView()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Inbox:");
            foreach (Mail mail in Inbox)
            {
                output.AppendLine(mail.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
