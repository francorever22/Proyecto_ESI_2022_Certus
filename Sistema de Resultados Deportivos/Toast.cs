using Microsoft.Toolkit.Uwp.Notifications;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using System.Drawing.Imaging;

namespace Sistema_de_Resultados_Deportivos
{
    internal class Toast
    {
        private static Toast baker = null;
        public Toast(int x, String title, String msg, int id)
        {
            baker = this;
            SelectBread(x, title, msg, id);
        }

        private void MatchBeginsToast(String title, String msg, int id)
        {
            new ToastContentBuilder()
            .AddText(title)
            .AddText(msg)
            .Show();
        }

        private void EventToast(String title, String msg, int id)
        {
            new ToastContentBuilder()
            .AddText(title)
            .AddText(msg)
            .Show();
        }

        private void SelectBread(int x, String title, String msg, int id)
        {
            switch (x)
            {
                case 0:
                    baker.MatchBeginsToast(title, msg, id);
                    break;
                case 1:
                    baker.EventToast(title, msg, id);
                    break;
            }
        }

        private Uri NewImage(Bitmap image1, Bitmap image2, int type, String textImage)
        {
            /* Types 
             * 1) Match beginnig
             * 2) Match score */
            Bitmap first;
            Bitmap second;
            Directory.CreateDirectory(@"C:\Certus\SRD\Toast");
            string FilePath = $@"C:\\Certus\\SRD\\Toast\\toast.png";
            switch (type)
            {
                case 1: //For VS
                    Bitmap vs = new Bitmap(Properties.Resources.versus);

                    first = new Bitmap(image1.Width + vs.Width, 180);
                    using (Graphics g = Graphics.FromImage(first))
                    {
                        g.DrawImage(image1, 0, 15);
                        g.DrawImage(vs, image1.Width, 0);
                    }

                    second = new Bitmap(first.Width + image2.Width, 180);
                    using (Graphics g = Graphics.FromImage(second))
                    {
                        g.DrawImage(first, 0, 0);
                        g.DrawImage(image2, first.Width, 15);
                    }

                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            second.Save(memory, ImageFormat.Png);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    break;
                case 2: //For score
                    Bitmap score = new Bitmap(GetText(textImage, 1));

                    first = new Bitmap(image1.Width + score.Width, 180);
                    using (Graphics g = Graphics.FromImage(first))
                    {
                        g.DrawImage(image1, 0, 15);
                        g.DrawImage(score, image1.Width, 90 - score.Height/2);
                    }

                    second = new Bitmap(first.Width + image2.Width, 180);
                    using (Graphics g = Graphics.FromImage(second))
                    {
                        g.DrawImage(first, 0, 0);
                        g.DrawImage(image2, first.Width, 15);
                    }

                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            second.Save(memory, ImageFormat.Png);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    break;
                case 3: //For round

                    Bitmap r = new Bitmap(GetText("Round", 2));
                    Bitmap nRound = new Bitmap(GetText(textImage, 2));
                    Bitmap round = new Bitmap(r.Width, r.Height + nRound.Height);
                    using (Graphics g = Graphics.FromImage(round))
                    {
                        g.DrawImage(r, 0, 0);
                        g.DrawImage(nRound, -5, r.Height);
                    }

                    first = new Bitmap(image1.Width + round.Width, 180);
                    using (Graphics g = Graphics.FromImage(first))
                    {
                        g.DrawImage(image1, 0, 15);
                        g.DrawImage(round, image1.Width, 90 - round.Height / 2);
                    }

                    second = new Bitmap(first.Width + image2.Width, 180);
                    using (Graphics g = Graphics.FromImage(second))
                    {
                        g.DrawImage(first, 0, 0);
                        g.DrawImage(image2, first.Width, 15);
                    }

                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            second.Save(memory, ImageFormat.Png);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    break;
                case 4: //For single images

                    first = new Bitmap(364, 180);
                    using (Graphics g = Graphics.FromImage(first))
                    {
                        g.DrawImage(image1, 107, 15);
                    }

                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            first.Save(memory, ImageFormat.Png);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    break;
            }
            Uri uri = new Uri(FilePath);
            return uri;
        }

        private Bitmap GetText(String text, int size)
        {
            Bitmap s = null;
            Font drawFont = null;
            SolidBrush drawBrush = new SolidBrush(Color.White);
            StringFormat drawFormat = new StringFormat();
            switch (size)
            {
                case 1:
                    drawFont = new Font("Segoe UI", 30);

                    s = new Bitmap(text.Length * 20, 80);

                    using (Graphics g = Graphics.FromImage(s))
                    {
                        g.DrawString(text, drawFont, drawBrush, 0, 0, drawFormat);
                    }
                    break;
                case 2:
                    drawFont = new Font("Segoe UI", 20);

                    s = new Bitmap(180, 40);
                    float x = (180 - text.Length * 20) / 2;

                    using (Graphics g = Graphics.FromImage(s))
                    {
                        g.DrawString(text, drawFont, drawBrush, x, 0, drawFormat);
                    }
                    break;
            }
            return s;
        }

        public void SendMail(string receptor, string title, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("Certus.SRL@gmail.com"));
            email.To.Add(MailboxAddress.Parse(receptor));
            email.Subject = title;
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>"+body+"</h1>" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("Certus.SRL@gmail.com", "khzjnzequehueazq");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
